using Microsoft.Extensions.DependencyInjection;

namespace Almostengr.LightShow.ConnectServices.RunModeManager;

public static class RunModeExtensions
{
    public static void AddRunModeServices(this IServiceCollection services)
    {
        services.AddTransient<IQueryRunModeService, QueryRunModeService>();
        services.AddTransient<IUpdateRunModeService, UpdateRunModeService>();
    }
}