namespace RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.EmailResponse;
public sealed record EmailCustomerResponse
{
    public int EmailAddressId { get; set; }
    public required string EmailAddress { get; set; }
}
