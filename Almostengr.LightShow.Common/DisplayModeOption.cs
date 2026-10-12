using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.LightShow.Common;

public enum DisplayModeOption
{
    Offline = 1,

    [Description("Online, Rejecting Requests")]
    [Display(Name = "Online, Rejecting Requests")]
    OnlineRejectingRequests = 2,

    [Description("Online, Accepting Requests")]
    [Display(Name = "Online, Accepting Requests")]
    OnlineAcceptingRequests = 3,
}