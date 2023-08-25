using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.EmailResponse;
using RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;
using RichDomain.API.Business.Domain.Entities;

namespace RichDomain.API.Business.ApplicationService.Mappers;
public sealed class EmailAddressMapper : IEmailAddressMapper
{
    public Email DtoRegisterToDomain(EmailAddressCustomerRegisterRequest dtoEmail) =>
        new(dtoEmail.EmailAddress);

    public List<Email> DtoRegisterToDomain(List<EmailAddressCustomerRegisterRequest> dtoEmails)
    {
        List<Email> emails = new();

        foreach (var dtoEmail in dtoEmails)
        {
            var email = DtoRegisterToDomain(dtoEmail);

            emails.Add(email);
        }

        return emails;
    }

    public EmailCustomerResponse DomainToCustomerDtoResponse(Email email) =>
        new()
        {
            EmailAddressId = email.EmailId,
            EmailAddress = email.EmailAddress
        };

    public List<EmailCustomerResponse> DomainToCustomerDtoResponse(List<Email> emails)
    {
        List<EmailCustomerResponse> dtoEmails = new();

        foreach (var email in emails)
        {
            var dtoEmail = DomainToCustomerDtoResponse(email);

            dtoEmails.Add(dtoEmail);
        }

        return dtoEmails;
    }
}
