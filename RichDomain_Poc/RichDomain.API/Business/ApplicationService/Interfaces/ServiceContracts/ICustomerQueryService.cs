using RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;

namespace RichDomain.API.Business.ApplicationService.Interfaces.ServiceContracts;
public interface ICustomerQueryService
{
    Task<CustomerWithEmailAndCellPhoneResponse?> FindByCustomerIdAsync(int customerId);

    Task<IEnumerable<CustomerDataResponse>> FindAllCustomerWithEmailAndMainTelephoneAsync();
}
