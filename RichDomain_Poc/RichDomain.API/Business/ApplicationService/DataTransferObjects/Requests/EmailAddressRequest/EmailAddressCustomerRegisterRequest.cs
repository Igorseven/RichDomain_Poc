using RichDomain.API.Business.Domain.Enums;

namespace RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
public sealed record EmailAddressCustomerRegisterRequest
{
    public required string EmailAddress { get; init; }
}
