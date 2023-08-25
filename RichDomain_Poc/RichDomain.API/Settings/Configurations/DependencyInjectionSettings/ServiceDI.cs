using RichDomain.API.Business.ApplicationService.Interfaces.ServiceContracts;
using RichDomain.API.Business.ApplicationService.Services.CustomerServices;

namespace RichDomain.API.Settings.Configurations.DependencyInjectionSettings;

public static class ServiceDI
{
    public static IServiceCollection AddServiceDI(this IServiceCollection services) =>
        services.AddScoped<ICustomerQueryService, CustomerQueryService>()
                .AddScoped<ICustomerCommandService, CustomerCommandService>();
}
