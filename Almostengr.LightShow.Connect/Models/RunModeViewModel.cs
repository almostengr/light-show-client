using Almostengr.LightShow.Connect.Services.RunModeManager;
using Almostengr.LightShow.Common;

namespace Almostengr.LightShow.Connect.Models;

public class RunModeViewModel
{
    public RunModeViewModel()
    {
    }

    public RunModeViewModel(RunModeResource resource)
    {
        ModeOption = resource.ModeOption;
        ModeId = (int)resource.ModeOption;
    }

    public DisplayModeOption ModeOption { get; set; }
    public int ModeId { get; set; }

    public void AssignToResource(RunModeResource resource)
    {
        if (resource == null)
        {
            return;
        }

        resource.ModeOption = (DisplayModeOption)ModeId;
    }
}