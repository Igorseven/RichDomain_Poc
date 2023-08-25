using RichDomain.API.Business.Domain.Entities;
using RichDomain.API.Business.Domain.Interfaces.OthersContracts;
using RichDomain.API.Business.Insfrastructure.Services;

namespace RichDomain.API.Settings.Configurations.DependencyInjectionSettings;

public static class PaginationDI
{
    public static IServiceCollection AddPaginationDI(this IServiceCollection services) =>
        services.AddScoped<IPaginationQueryService<Customer>, PaginationQueryService<Customer>>();
}
