using Almostengr.LightShow.Common;

namespace Almostengr.LightShow.Connect.Services.RunModeManager.Domain;

public static class RunMode
{
    public static DisplayModeOption ModeOption { get; private set; } = DisplayModeOption.Offline;

    public static void Update(DisplayModeOption option)
    {
        ModeOption = option;
    }
}
