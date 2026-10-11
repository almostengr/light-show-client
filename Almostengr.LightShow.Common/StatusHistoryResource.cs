namespace Almostengr.LightShow.Common;

public sealed class StatusHistoryResource : ApiResource
{
    public string CurrentSequence { get; set; }
    public string CurrentSong { get; set; }
    public int Warnings { get; set; }
    public int DisplayId { get; set; }
    public DisplayModeOption ModeOption { get; set; }
}