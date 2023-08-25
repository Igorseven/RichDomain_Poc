using RichDomain.API.Business.Domain.Entities;

namespace RichDomain.UnitTest.Builders;
public sealed class EmailBuilderTest
{
    private string _emailAddress = "email@test.com";
    private int _customerId = 1;

    public static EmailBuilderTest NewObject() => new();

    public Email DomainObject() =>
        new(_emailAddress,
            _customerId);

    public EmailBuilderTest WithEmailAddress(string emailAddress)
    {
        _emailAddress = emailAddress;
        return this;
    }

    public EmailBuilderTest WithCustomerId(int customerId)
    {
        _customerId = customerId;
        return this;
    }

}
