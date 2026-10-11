using System.ComponentModel;

namespace Almostengr.LightShow.Common;

public enum DisplayModeOption
{
    Offline = 1,

    [Description("Online, Rejecting Requests")]
    OnlineRejectingRequests = 2,

    [Description("Online, Accepting Requests")]
    OnlineAcceptingRequests = 3,
}