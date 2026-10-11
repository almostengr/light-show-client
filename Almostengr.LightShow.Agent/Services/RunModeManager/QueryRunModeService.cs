using Almostengr.LightShow.Agent.Services.RunModeManager.Domain;

namespace Almostengr.LightShow.Agent.Services.RunModeManager;

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
