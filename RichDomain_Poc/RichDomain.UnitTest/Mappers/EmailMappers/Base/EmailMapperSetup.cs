using RichDomain.API.Business.ApplicationService.Mappers;

namespace RichDomain.UnitTest.Mappers.EmailMappers.Base;
public abstract class EmailMapperSetup
{
    protected readonly EmailMapper _emailMapper;

    public EmailMapperSetup()
    {
        _emailMapper = new();
    }
}
