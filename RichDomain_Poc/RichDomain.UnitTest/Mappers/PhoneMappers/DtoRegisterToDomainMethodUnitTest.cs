using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.PhoneRequest;
using RichDomain.UnitTest.Mappers.PhoneMappers.Base;

namespace RichDomain.UnitTest.Mappers.PhoneMappers;
public sealed class DtoRegisterToDomainMethodUnitTest : PhoneMapperSetup
{
    [Fact]
    [Trait("Mapping", "Dto register to domain")]
    public void DtoRegisterToDomain_ReturnTelephone()
    {
        var cellphoneNumber = "1191077-5566";
        var telephoneNumber = "113371-5566";
        var dtoTelephone = new PhoneCustomerRegisterRequest(cellphoneNumber,
                                                            telephoneNumber);

        var mappingResult = _phoneMapper.DtoRegisterToDomain(dtoTelephone);

        Assert.NotNull(mappingResult);
        Assert.Equal("11910775566", mappingResult.CellPhoneNumber);
        Assert.Equal("1133715566", mappingResult.TelephoneNumber);
    }
}
