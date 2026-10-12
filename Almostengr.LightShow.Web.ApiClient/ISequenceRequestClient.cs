using Almostengr.LightShow.Common;

namespace Almostengr.LightShow.Web.ApiClient;

public interface ISequenceRequestClient
{
    Task<SequenceRequestResource> GetNextAsync();
}