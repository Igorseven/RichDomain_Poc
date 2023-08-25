using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;

namespace RichDomain.API.Business.ApplicationService.Interfaces.ServiceContracts;
public interface ICustomerCommandService : IDisposable
{
    Task<bool> CustomerRegisterAsync(CustomerRegisterRequest dtoCustomer);
}
