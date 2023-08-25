using RichDomain.API.Business.Domain.Handlers.NotificationHandler;
using RichDomain.API.Business.Domain.Interfaces.OthersContracts;
using RichDomain.API.Business.Domain.Providers;
using RichDomain.API.Business.Insfrastructure.ORM.Context;
using RichDomain.API.Business.Insfrastructure.ORM.UoW;
using RichDomain.API.Settings.Configurations.DependencyInjectionSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace RichDomain.API.Settings.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(sp => sp.GetService<IOptionsMonitor<ConnectionStringOptions>>()!.CurrentValue);
        services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));

        services.AddScoped<ApplicationContext>()
                .AddScoped<INotificationHandler, NotificationHandler>()
                .AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<ApplicationContext>((serviceProv, options) =>
           options.UseSqlServer(serviceProv.GetRequiredService<ConnectionStringOptions>().DefaultConnection, sql => sql.CommandTimeout(180)));


        services.AddRepositoryDI()
                .AddPaginationDI()
                .AddServiceDI()
                .AddEntityMapperDI();

        return services;
    }
}
