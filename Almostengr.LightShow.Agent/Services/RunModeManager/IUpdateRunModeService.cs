using Almostengr.Common.Common.DomainServices.Results;

namespace Almostengr.LightShow.Agent.Services.RunModeManager;

public interface IUpdateRunModeService
{
    Result<RunModeResource> Execute(RunModeResource resource);
}