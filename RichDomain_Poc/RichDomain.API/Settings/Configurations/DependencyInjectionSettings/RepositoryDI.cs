using RichDomain.API.Business.Domain.Interfaces.RepositoryContracts;
using RichDomain.API.Business.Insfrastructure.Repository;

namespace RichDomain.API.Settings.Configurations.DependencyInjectionSettings;

public static class RepositoryDI
{
    public static IServiceCollection AddRepositoryDI(this IServiceCollection services) =>
        services.AddScoped<ICustomerRepository, CustomerRepository>();
}
