using RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.EmailResponse;
using RichDomain.API.Business.Domain.Enums;

namespace RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
public sealed record CustomerWithEmailAndCellPhoneResponse(int CustomerId,
                                                           string FirstName,
                                                           string LastName,
                                                           ECustomerType CustomerType,
                                                           string CellPhoneNumber,
                                                           EmailCustomerResponse Email
                                                           );

