using Almostengr.Common.Common.Infrastructure;
using Almostengr.LightShow.Common;
using Microsoft.Extensions.Options;

namespace Almostengr.LightShow.Web.ApiClient;

public sealed class SequenceRequestClient : ISequenceRequestClient
{
    private readonly LightShowSettings _settings;
    private readonly HttpClient _httpClient;

    public SequenceRequestClient(
        IOptionsSnapshot<LightShowSettings> options,
        HttpClient httpClient
    )
    {
        _settings = options.Value;

        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(_settings.HostUrl);
        _httpClient.Timeout = TimeSpan.FromSeconds(_settings.Timeout);
    }

    public async Task<SequenceRequestResource> GetNextAsync()
    {
        string route = "api/sequencerequests";
        SequenceRequestResource response = await _httpClient.GetAsync<SequenceRequestResource>(route);
        return response;
    }
}
