using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.PhoneRequest;
using RichDomain.API.Business.Domain.Enums;

namespace RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
public sealed record CustomerRegisterRequest(string FirstName,
                                             string LastName,
                                             ECustomerType CustomerType,
                                             PhoneCustomerRegisterRequest Phone,
                                             EmailCustomerRegisterRequest Email
                                            );

