using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.EmailResponse;
using RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;
using RichDomain.API.Business.Domain.Entities;

namespace RichDomain.API.Business.ApplicationService.Mappers;
public sealed class EmailMapper : IEmailAddressMapper
{
    public Email DtoRegisterToDomain(EmailCustomerRegisterRequest dtoEmail) =>
        new(dtoEmail.EmailAddress);

    public EmailCustomerResponse DomainToCustomerDtoResponse(Email email) =>
        new(email.EmailId,
            email.EmailAddress);
}
