using Almostengr.LightShow.Agent.Services.RunModeManager;
using Almostengr.LightShow.Common;

namespace Almostengr.LightShow.Agent.Models;

public class RunModeViewModel
{
    public RunModeViewModel()
    {
    }

    public RunModeViewModel(RunModeResource resource)
    {
        ModeOption = resource.ModeOption;
    }

    public DisplayModeOption ModeOption { get; private set; }

    public void AssignToResource(RunModeResource resource)
    {
        if (resource == null)
        {
            return;
        }

        resource.ModeOption = ModeOption;
    }
}