using Almostengr.Common.Common.DomainServices.Interfaces;

namespace Almostengr.LightShow.Connect.Services.AppSettingsManager;

public static class AppSettingsExtensions
{
    public static void AddAppSettingsServices(this IServiceCollection services)
    {
        services.AddTransient<IQueryAppSettingsService, QueryAppSettingsService>();
        services.AddTransient<IUpdateService<AppSettingsResource>, UpdateAppSettingsService>();
    }
}