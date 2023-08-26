using Moq;
using RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;
using RichDomain.API.Business.ApplicationService.Mappers;

namespace RichDomain.UnitTest.Mappers.CustomerMappers.Base;
public abstract class CustomerMapperSetup
{
    protected readonly Mock<IEmailMapper> _emailMapper;
    protected readonly Mock<IPhoneMapper> _phoneMapper;
    protected readonly CustomerMapper _customerMapper;

    public CustomerMapperSetup()
    {
        _emailMapper = new();
        _phoneMapper = new();
        _customerMapper = new(_emailMapper.Object,
                              _phoneMapper.Object);
    }
}
