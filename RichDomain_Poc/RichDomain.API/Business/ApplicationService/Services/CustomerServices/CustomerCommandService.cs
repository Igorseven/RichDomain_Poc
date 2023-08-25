using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
using RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;
using RichDomain.API.Business.ApplicationService.Interfaces.ServiceContracts;
using RichDomain.API.Business.Domain.Interfaces.OthersContracts;
using RichDomain.API.Business.Domain.Interfaces.RepositoryContracts;

namespace RichDomain.API.Business.ApplicationService.Services.CustomerServices;
public sealed class CustomerCommandService : BaseService, ICustomerCommandService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerMapper _customerMapper;

    public CustomerCommandService(INotificationHandler notification,
                                  ICustomerRepository customerRepository,
                                  ICustomerMapper customerMapper)
        : base(notification)
    {
        _customerRepository = customerRepository;
        _customerMapper = customerMapper;
    }

    public void Dispose() => _customerRepository.Dispose();

    public async Task<bool> CustomerRegisterAsync(CustomerRegisterRequest dtoCustomer)
    {
        var customer = _customerMapper.DtoRegisterToDomain(dtoCustomer);

        if (!EntityValidation(customer.GetErrors())) return false;

        return await _customerRepository.SaveAsync(customer);
    }
}
