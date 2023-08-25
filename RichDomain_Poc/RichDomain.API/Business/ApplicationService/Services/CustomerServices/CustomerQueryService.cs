using Microsoft.EntityFrameworkCore;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
using RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;
using RichDomain.API.Business.ApplicationService.Interfaces.ServiceContracts;
using RichDomain.API.Business.Domain.Interfaces.RepositoryContracts;

namespace RichDomain.API.Business.ApplicationService.Services.CustomerServices;
public sealed class CustomerQueryService : ICustomerQueryService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerMapper _customerMapper;

    public CustomerQueryService(ICustomerRepository customerRepository,
                                ICustomerMapper customerMapper)
    {
        _customerRepository = customerRepository;
        _customerMapper = customerMapper;
    }

    public async Task<IEnumerable<CustomerDataResponse>> FindAllCustomerWithEmailAndMainTelephoneAsync()
    {
        var customers = await _customerRepository.FindAllAsync(c => c.Include(c => c.Email));

        if (!customers.Any()) return Enumerable.Empty<CustomerDataResponse>();

        return _customerMapper.DomainToDataDtoResponse(customers);
    }

    public async Task<CustomerWithEmailAndCellPhoneResponse?> FindByCustomerIdAsync(int customerId)
    {
        var customer = await _customerRepository.FindByPredicateAsync(c => c.CustomerId == customerId,
                                                                      c => c.Include(c => c.Email),
                                                                      true);

        if (customer is null) return null;

        return _customerMapper.DomainToEmailAndMainAddressDtoResponse(customer);
    }
}
