using Almostengr.Common.Common.DomainServices.Resources;
using Almostengr.LightShow.Connect.Services.AppSettingsManager.Domain;

namespace Almostengr.LightShow.Connect.Services.AppSettingsManager;

public sealed class AppSettingsResource : Resource
{
    public string PlayerUrl { get; set; }
    public string WebsiteUrl { get; set; }
    public string WebsiteApiKey { get; set; }
    public PlayerTypeOption TypeOption { get; set; }
    public int WorkerSleepInterval { get; set; }
}