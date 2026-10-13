using Almostengr.LightShow.Common;

namespace Almostengr.LightShow.WebApiClient;

public interface ISequenceRequestClient
{
    Task<SequenceRequestResource> GetNextAsync();
}