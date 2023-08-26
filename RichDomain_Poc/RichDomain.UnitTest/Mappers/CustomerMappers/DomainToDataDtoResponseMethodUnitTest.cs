using RichDomain.API.Business.Domain.Entities;
using RichDomain.API.Business.Domain.Enums;
using RichDomain.UnitTest.Builders;
using RichDomain.UnitTest.Mappers.CustomerMappers.Base;

namespace RichDomain.UnitTest.Mappers.CustomerMappers;
public sealed class DomainToDataDtoResponseMethodUnitTest : CustomerMapperSetup
{
    [Fact]
    [Trait("Mapping", "Domain to data response")]
    public void DomainToDataDtoResponse_ReturnCustomerDataResponse()
    {
        var firstName = "First Name";
        var lastName = "Last Name";
        var customerType = ECustomerType.Active;
        var customer = CustomerBuilderTest.NewObject()
                                          .WithFirstName(firstName)
                                          .WithLastName(lastName)
                                          .WithCustomerType(customerType)
                                          .DomainObject();

        var mappingResult = _customerMapper.DomainToDataDtoResponse(customer);

        Assert.NotNull(mappingResult);
        Assert.Equal(customer.FirstName, mappingResult.FirstName);
        Assert.Equal(customer.LastName, mappingResult.LastName);
        Assert.Equal(customer.CustomerType, mappingResult.CustomerType);
    }
    
    [Fact]
    [Trait("Mapping", "Domain to data response list")]
    public void DomainToDataDtoResponse_ReturnCustomerDataResponseList()
    {
        List<Customer> customers = new()
        {
            { CustomerBuilderTest.NewObject().DomainObject() }
        };

        var mappingResult = _customerMapper.DomainToDataDtoResponse(customers);

        Assert.NotEmpty(mappingResult);
        Assert.True(mappingResult.Count == customers.Count);
        
    }
}
