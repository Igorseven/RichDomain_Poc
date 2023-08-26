using Moq;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.PhoneRequest;
using RichDomain.API.Business.Domain.Enums;
using RichDomain.UnitTest.Builders;
using RichDomain.UnitTest.Mappers.CustomerMappers.Base;

namespace RichDomain.UnitTest.Mappers.CustomerMappers;
public sealed class DtoRegisterToDomainMethodUnitTest : CustomerMapperSetup
{

    [Fact]
    [Trait("Mapping", "Dto register to domain")]
    public void DtoRegisterToDomain_ReturnCustomer()
    {
        var firstName = "First Name";
        var lastName = "Last Name";
        var status = ECustomerType.Active;
        var emailAddress = "email@teste.com";
        var cellPhone = "11910663355";
        var telephone = "1133716652";
        var phoneDto = new PhoneCustomerRegisterRequest(cellPhone, telephone);
        var emailDto = new EmailCustomerRegisterRequest(emailAddress);
        var customerDto = new CustomerRegisterRequest(firstName,
                                                      lastName,
                                                      status,
                                                      phoneDto,
                                                      emailDto);

        var email = EmailBuilderTest.NewObject()
                                    .WithEmailAddress(emailAddress)
                                    .DomainObject();

        var phone = PhoneBuilderTest.NewObject()
                                    .WithCellPhoneNumber(cellPhone)
                                    .WithTelephoneNumber(telephone)
                                    .DomainObject();

        _emailMapper.Setup(m => m.DtoRegisterToDomain(It.IsAny<EmailCustomerRegisterRequest>())).Returns(email);
        _phoneMapper.Setup(m => m.DtoRegisterToDomain(It.IsAny<PhoneCustomerRegisterRequest>())).Returns(phone);

        var mappingResult = _customerMapper.DtoRegisterToDomain(customerDto);

        Assert.NotNull(mappingResult);
        Assert.Equal(customerDto.FirstName, mappingResult.FirstName);
        Assert.Equal(customerDto.LastName, mappingResult.LastName);
        Assert.Equal(customerDto.CustomerType, mappingResult.CustomerType);
        _emailMapper.Verify(m => m.DtoRegisterToDomain(It.IsAny<EmailCustomerRegisterRequest>()), Times.Once());
        _phoneMapper.Verify(m => m.DtoRegisterToDomain(It.IsAny<PhoneCustomerRegisterRequest>()), Times.Once());
    }
}
