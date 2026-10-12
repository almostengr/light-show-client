using Almostengr.Common.Common.DomainServices.Results;

namespace Almostengr.LightShow.Connect.Services.RunModeManager;

public interface IUpdateRunModeService
{
    Result<RunModeResource> Execute(RunModeResource resource);
}