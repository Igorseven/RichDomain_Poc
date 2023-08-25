using RichDomain.API.Business.ApplicationService.Mappers;

namespace RichDomain.UnitTest.Mappers.PhoneMappers.Base;
public abstract class PhoneMapperSetup
{
    protected readonly PhoneMapper _phoneMapper;

	public PhoneMapperSetup()
	{
        _phoneMapper = new();

    }
}
