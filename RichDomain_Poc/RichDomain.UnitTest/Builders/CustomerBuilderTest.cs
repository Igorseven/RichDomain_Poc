using RichDomain.API.Business.Domain.Entities;
using RichDomain.API.Business.Domain.Enums;
using RichDomain.API.Business.Domain.ValueObjects;

namespace RichDomain.UnitTest.Builders;
public sealed class CustomerBuilderTest
{
    private string _firstName = "First Name";
    private string _lastName = "Last Name";
    private ECustomerType _customerType = ECustomerType.Active;
    private Email? _email = new("email@test.com");
    private Phone? _phone = new("11910778245", "1133711548");

    public static CustomerBuilderTest NewObject() => new();

    public Customer DomainObject() =>
        new(_firstName,
            _lastName,
            _customerType,
            _email!,
            _phone!);

    public CustomerBuilderTest WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public CustomerBuilderTest WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }

    public CustomerBuilderTest WithCustomerType(ECustomerType customerType)
    {
        _customerType = customerType;
        return this;
    }

    public CustomerBuilderTest WithEmail(string email)
    {
        _email = new Email(email);
        return this;
    }

     public CustomerBuilderTest WithPhone(string cellPhone, string? telephone)
    {
        _phone = new Phone(cellPhone, telephone);
        return this;
    }


}
