using Moq;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.EmailResponse;
using RichDomain.API.Business.Domain.Entities;
using RichDomain.API.Business.Domain.Enums;
using RichDomain.UnitTest.Builders;
using RichDomain.UnitTest.Mappers.CustomerMappers.Base;

namespace RichDomain.UnitTest.Mappers.CustomerMappers;
public sealed class DomainToEmailAndMainAddressDtoResponseMethodUnitTest : CustomerMapperSetup
{
    [Fact]
    [Trait("Mapping", "Domain to data response")]
    public void DomainToEmailAndMainAddressDtoResponse_ReturnCustomerWithEmailAndCellPhoneResponse()
    {
        var firstName = "First Name";
        var lastName = "Last Name";
        var customerType = ECustomerType.Active;
        var emailAddress = "email@teste.com";
        var cellPhone = "11910663355";
        var telephone = "1133716652";
        var customer = CustomerBuilderTest.NewObject()
                                          .WithFirstName(firstName)
                                          .WithLastName(lastName)
                                          .WithCustomerType(customerType)
                                          .WithPhone(cellPhone, telephone)
                                          .WithEmail(emailAddress)
                                          .DomainObject();

        var email = new EmailCustomerResponse(12,
                                              emailAddress);

        _emailMapper.Setup(m => m.DomainToCustomerDtoResponse(It.IsAny<Email>())).Returns(email);

        var mappingResult = _customerMapper.DomainToEmailAndMainAddressDtoResponse(customer);

        Assert.NotNull(mappingResult);
        Assert.Equal(customer.FirstName, mappingResult.FirstName);
        Assert.Equal(customer.LastName, mappingResult.LastName);
        Assert.Equal(customer.CustomerType, mappingResult.CustomerType);
        Assert.Equal(customer.Phone!.CellPhoneNumber, mappingResult.CellPhoneNumber);
        Assert.Equal(customer.Email!.EmailAddress, mappingResult.Email.EmailAddress);
        _emailMapper.Verify(m => m.DomainToCustomerDtoResponse(It.IsAny<Email>()), Times.Once());
    }
}
