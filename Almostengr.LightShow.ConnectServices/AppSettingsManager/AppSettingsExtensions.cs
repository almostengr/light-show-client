using Almostengr.Common.Common.DomainServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Almostengr.LightShow.ConnectServices.AppSettingsManager;

public static class AppSettingsExtensions
{
    public static void AddAppSettingsServices(this IServiceCollection services)
    {
        services.AddTransient<IQueryAppSettingsService, QueryAppSettingsService>();
        services.AddTransient<IUpdateService<AppSettingsResource>, UpdateAppSettingsService>();
    }
}