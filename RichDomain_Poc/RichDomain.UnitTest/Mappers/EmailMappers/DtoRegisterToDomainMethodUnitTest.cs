using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using RichDomain.UnitTest.Mappers.EmailMappers.Base;

namespace RichDomain.UnitTest.Mappers.EmailMappers;
public sealed class DtoRegisterToDomainMethodUnitTest : EmailMapperSetup
{
    [Fact]
    [Trait("Mapping", "Dto register to domain")]
    public void DtoRegisterToDomain_ReturnEmail()
    {
        var emailAddress = "email@test.com";
        var email = new EmailCustomerRegisterRequest(emailAddress);

        var mappingResult = _emailMapper.DtoRegisterToDomain(email);

        Assert.NotNull(mappingResult);
        Assert.Equal(email.EmailAddress, mappingResult.EmailAddress);
    }
}
