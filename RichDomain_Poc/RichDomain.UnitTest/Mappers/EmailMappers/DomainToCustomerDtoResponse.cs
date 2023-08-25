using RichDomain.API.Business.Domain.Entities;
using RichDomain.UnitTest.Mappers.EmailMappers.Base;

namespace RichDomain.UnitTest.Mappers.EmailMappers;
public sealed class DomainToCustomerDtoResponse : EmailMapperSetup
{
    [Fact]
    [Trait("Mapping", "Domain to customer response")]
    public void DomainToCustomerDtoResponse_ReturnEmailCustomerResponse()
    {
        var emailAddress = "email@test.com";
        var email = new Email(emailAddress);

        var mappingResult = _emailMapper.DomainToCustomerDtoResponse(email);

        Assert.NotNull(mappingResult);
        Assert.Equal(email.EmailAddress, mappingResult.EmailAddress);
    }
}
