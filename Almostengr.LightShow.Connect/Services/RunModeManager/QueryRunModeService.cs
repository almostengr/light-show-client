using Almostengr.LightShow.Connect.Services.RunModeManager.Domain;

namespace Almostengr.LightShow.Connect.Services.RunModeManager;

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
