namespace RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.PhoneRequest;

public sealed record PhoneCustomerRegisterRequest(string CellPhoneNumber,
                                                  string TelephoneNumber);

