using Almostengr.Common.Common.DomainServices.Results;
using Almostengr.FalconPiPlayer.ApiClient.Fppd.DomainServices.Interfaces;
using Almostengr.FalconPiPlayer.ApiClient.Fppd.DomainServices.Resources;
using Almostengr.LightShow.ConnectServices.AppSettingsManager.Domain;
using Almostengr.LightShow.ConnectServices.RunModeManager.Domain;
using Almostengr.LightShow.Common;
using Almostengr.LightShow.WebApiClient;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Almostengr.LightShow.ConnectServices;

public sealed class AgentWorker : BackgroundService
{
    private readonly ILogger<AgentWorker> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private AppSettings.AgentSettings _agentSettings;
    private StatusHistoryResource _lastResource;

    public AgentWorker(
        ILogger<AgentWorker> logger,
        IOptionsMonitor<AppSettings.AgentSettings> options,
        IServiceScopeFactory scopeFactory
    )
    {
        _lastResource = null;
        _logger = logger;
        _agentSettings = options.CurrentValue;
        options.OnChange(agentsettings =>
        {
            _agentSettings = agentsettings;
        });
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();
            var fppdClient = scope.ServiceProvider.GetRequiredService<IFppdClient>();
            var statusHistoryClient = scope.ServiceProvider.GetRequiredService<IStatusHistoryClient>();
            return;
            try
            {
                FppdStatusResource fppStatus = await fppdClient.GetStatusAsync();
                if (fppStatus == null)
                {
                    await DelayAsync(stoppingToken);
                    continue;
                }

                var currentResource = AssignToResource(fppStatus);
                if (_lastResource == currentResource)
                {
                    await DelayAsync(stoppingToken);
                    continue;
                }

                var statusResult = await statusHistoryClient.CreateAsync(currentResource);
                if (statusResult.Failed)
                {
                    _logger.LogWarning(statusResult.ToErrorString());
                }

                var requestResult = await GetNextRequestAsync();
                if (requestResult.Failed)
                {
                    _logger.LogWarning(requestResult.ToErrorString());
                }

                _lastResource = currentResource;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            await DelayAsync(stoppingToken);
        }
    }

    private async Task<Result<int>> GetNextRequestAsync()
    {
        if (RunMode.ModeOption == DisplayModeOption.OnlineAcceptingRequests)
        {
            return Result<int>.Failure(string.Empty);
        }

        throw new NotImplementedException();
    }

    private static StatusHistoryResource AssignToResource(FppdStatusResource statusResource)
    {
        if (statusResource == null)
        {
            return null;
        }

        return new StatusHistoryResource
        {
            CurrentSequence = statusResource.CurrentSequence,
            CurrentSong = statusResource.CurrentSong,
            Warnings = 0,
            ModeOption = RunMode.ModeOption,
        };
    }

    private async Task DelayAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(_agentSettings.WorkerSleepInterval), cancellationToken);
    }
}
