using RichDomain.API.Business.Domain.Enums;

namespace RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
public sealed record CustomerDataResponse(int CustomerId,
                                          string FirstName,
                                          string LastName,
                                          ECustomerType CustomerType
                                          );
