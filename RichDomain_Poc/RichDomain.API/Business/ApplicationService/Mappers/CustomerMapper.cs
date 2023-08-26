using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
using RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;
using RichDomain.API.Business.Domain.Entities;

namespace RichDomain.API.Business.ApplicationService.Mappers;
public sealed class CustomerMapper : ICustomerMapper
{
    private readonly IEmailMapper _emailsMapper;
    private readonly IPhoneMapper _phoneMapper;

    public CustomerMapper(IEmailMapper emailAddressMapper,
                          IPhoneMapper phoneMapper)
    {
        _emailsMapper = emailAddressMapper;
        _phoneMapper = phoneMapper;
    }

    public Customer DtoRegisterToDomain(CustomerRegisterRequest dtoCustomer)
    {
        var email = _emailsMapper.DtoRegisterToDomain(dtoCustomer.Email);
        var phone = _phoneMapper.DtoRegisterToDomain(dtoCustomer.Phone);

        return new(dtoCustomer.FirstName, 
                   dtoCustomer.LastName, 
                   dtoCustomer.CustomerType, 
                   email, 
                   phone);
    }



    public CustomerDataResponse DomainToDataDtoResponse(Customer customer) =>
        new(customer.CustomerId,
            customer.FirstName,
            customer.LastName,
            customer.CustomerType);
            

    public List<CustomerDataResponse> DomainToDataDtoResponse(List<Customer> customers)
    {
        List<CustomerDataResponse> dtoCustomers = new();

        foreach (var customer in customers)
        {
            var dtoCustomer = DomainToDataDtoResponse(customer); 
            
            dtoCustomers.Add(dtoCustomer);
        }

        return dtoCustomers;
    }



    public CustomerWithEmailAndCellPhoneResponse DomainToEmailAndMainAddressDtoResponse(Customer customer)
    {
        var dtoEmail = _emailsMapper.DomainToCustomerDtoResponse(customer.Email!);

        return new(customer.CustomerId,
                   customer.FirstName,
                   customer.LastName,
                   customer.CustomerType,
                   customer.Phone!.CellPhoneNumber,
                   dtoEmail);
    }
        
}
