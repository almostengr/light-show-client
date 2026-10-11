using Almostengr.Common.Common.DomainServices.Results;
using Almostengr.LightShow.Agent.Services.RunModeManager.Domain;

namespace Almostengr.LightShow.Agent.Services.RunModeManager;

public sealed class UpdateRunModeService : IUpdateRunModeService
{
    public UpdateRunModeService()
    {
    }

    public Result<RunModeResource> Execute(RunModeResource resource)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(resource, nameof(resource));

            RunMode.Update(resource.ModeOption);

            return Result<RunModeResource>.Success(resource);
        }
        catch (Exception ex)
        {
            return Result<RunModeResource>.Failure(ex.Message);
        }
    }
}
