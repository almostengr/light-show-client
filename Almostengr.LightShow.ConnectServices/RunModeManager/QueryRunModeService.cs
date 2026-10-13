using Almostengr.LightShow.ConnectServices.RunModeManager.Domain;

namespace Almostengr.LightShow.ConnectServices.RunModeManager;

public sealed class QueryRunModeService : IQueryRunModeService
{
    public RunModeResource Get()
    {
        return new RunModeResource
        {
            ModeOption = RunMode.ModeOption,
        };
    }
}
