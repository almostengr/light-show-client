using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Almostengr.LightShow.Web.ApiClient;

public static class LightShowWebExtensions
{
    public static void AddLightShowWebServices(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.Configure<LightShowSettings>(configuration.GetSection(nameof(LightShowSettings)));
        services.AddTransient<IStatusHistoryClient, StatusHistoryClient>();
        services.AddTransient<ISequenceRequestClient, SequenceRequestClient>();
    }
}