using RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;
using RichDomain.API.Business.ApplicationService.Mappers;

namespace RichDomain.API.Settings.Configurations.DependencyInjectionSettings;

public static class EntityMapperDI
{
    public static IServiceCollection AddEntityMapperDI(this IServiceCollection services) =>
        services.AddScoped<ICustomerMapper, CustomerMapper>()
                .AddScoped<IPhoneMapper, PhoneMapper>()
                .AddScoped<IEmailAddressMapper, EmailAddressMapper>();
        
}
