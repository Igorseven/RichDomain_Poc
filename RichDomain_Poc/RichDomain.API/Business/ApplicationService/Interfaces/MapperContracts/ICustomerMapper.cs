using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
using RichDomain.API.Business.Domain.Entities;

namespace RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;
public interface ICustomerMapper
{
    Customer DtoRegisterToDomain(CustomerRegisterRequest dtoCustomer);

    CustomerDataResponse DomainToDataDtoResponse(Customer customer);

    List<CustomerDataResponse> DomainToDataDtoResponse(List<Customer> customers);

    CustomerWithEmailAndCellPhoneResponse DomainToEmailAndMainAddressDtoResponse(Customer customer);

}
