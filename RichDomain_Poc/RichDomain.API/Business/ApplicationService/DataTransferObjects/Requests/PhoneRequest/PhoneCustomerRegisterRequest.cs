namespace RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.PhoneRequest;

public sealed record PhoneCustomerRegisterRequest
{
    public required string CellPhoneNumber { get; init; }
    public string? TelephoneNumber { get; init; }
}
