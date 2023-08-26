using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.EmailResponse;
using RichDomain.API.Business.Domain.Entities;

namespace RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;
public interface IEmailMapper
{
    Email DtoRegisterToDomain(EmailCustomerRegisterRequest dtoEmail);
    EmailCustomerResponse DomainToCustomerDtoResponse(Email email);
}
