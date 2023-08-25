using RichDomain.API.Settings.Configurations;

namespace RichDomain.API.Settings;

public static class SettingsHandler
{
    public static IServiceCollection AddSettingsConfigurations(this IServiceCollection services, IConfiguration configuration) =>
        services.AddControllersConfiguration()
                .AddFiltersConfiguration()
                .AddCorsConfiguration()
                .AddSwaggerConfiguration()
                .AddDependencyInjectionConfiguration(configuration);
}
