using Almostengr.Common.Common.DomainServices.Results;

namespace Almostengr.LightShow.ConnectServices.RunModeManager;

public interface IUpdateRunModeService
{
    Result<RunModeResource> Execute(RunModeResource resource);
}