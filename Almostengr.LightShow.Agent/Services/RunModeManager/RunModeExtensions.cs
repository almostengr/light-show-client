namespace Almostengr.LightShow.Agent.Services.RunModeManager;

public static class RunModeExtensions
{
    public static void AddRunModeServices(this IServiceCollection services)
    {
        services.AddTransient<IQueryRunModeService, QueryRunModeService>();
        services.AddTransient<IUpdateRunModeService, UpdateRunModeService>();
    }
}