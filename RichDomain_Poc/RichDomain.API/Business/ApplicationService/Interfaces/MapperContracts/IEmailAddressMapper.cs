using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.EmailResponse;
using RichDomain.API.Business.Domain.Entities;

namespace RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;
public interface IEmailAddressMapper
{
    Email DtoRegisterToDomain(EmailAddressCustomerRegisterRequest dtoEmail);
    List<Email> DtoRegisterToDomain(List<EmailAddressCustomerRegisterRequest> dtoEmails);
    EmailCustomerResponse DomainToCustomerDtoResponse(Email email);
    List<EmailCustomerResponse> DomainToCustomerDtoResponse(List<Email> emails);
}
