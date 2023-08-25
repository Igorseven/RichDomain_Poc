using Bogus.Extensions;
using RichDomain.UnitTest.Builders;

namespace RichDomain.UnitTest.Validations;
public sealed class CustomerValidationUnitTest
{
    [Fact]
    [Trait("Success", "Perfect setting")]
    public void CustomerValidation_PerfectSetting_IsValid()
    {
        var customer = CustomerBuilderTest.NewObject().DomainObject();

        Assert.True(customer.IsValid);
        Assert.Empty(customer.GetErrors());
    }

    public static IEnumerable<object[]> InvalidFirstName()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Person.FirstName.ClampLength(1, 2)},
            new object[] {new Bogus.Faker().Person.FirstName.ClampLength(71, 75)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid first name")]
    [MemberData(nameof(InvalidFirstName))]
    public void CustomerValidation_InvalidFirstName_Invalid(string firstName)
    {
        var customer = CustomerBuilderTest.NewObject()
                                          .WithFirstName(firstName)
                                          .DomainObject();

        Assert.False(customer.IsValid);
        Assert.NotEmpty(customer.GetErrors());
    }

    public static IEnumerable<object[]> InvalidLastName()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Person.LastName.ClampLength(1, 2)},
            new object[] {new Bogus.Faker().Person.LastName.ClampLength(71, 75)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid last name")]
    [MemberData(nameof(InvalidLastName))]
    public void CustomerValidation_InvalidLastName_Invalid(string lastName)
    {
        var customer = CustomerBuilderTest.NewObject()
                                          .WithLastName(lastName)
                                          .DomainObject();

        Assert.False(customer.IsValid);
        Assert.NotEmpty(customer.GetErrors());
    }

    public static IEnumerable<object[]> InvalidCellPhone()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Person.Phone.ClampLength(1, 10)},
            new object[] {new Bogus.Faker().Person.Phone.ClampLength(15, 20)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid Cell phone")]
    [MemberData(nameof(InvalidCellPhone))]
    public void CustomerValidation_InvalidCellphone_Invalid(string cellPhoneNumber)
    {
        var telephoneNumber = "1133711548";
        var customer = CustomerBuilderTest.NewObject()
                                          .WithPhone(cellPhoneNumber, telephoneNumber)
                                          .DomainObject();

        Assert.False(customer.IsValid);
        Assert.NotEmpty(customer.GetErrors());
    }

    public static IEnumerable<object[]> InvalidTelePhone()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Person.Phone.ClampLength(1, 9)},
            new object[] {new Bogus.Faker().Person.Phone.ClampLength(13, 20)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid Telephone")]
    [MemberData(nameof(InvalidTelePhone))]
    public void CustomerValidation_InvalidTelephone_Invalid(string telephoneNumber)
    {
        var cellPhoneNumber = "1133711548";
        var customer = CustomerBuilderTest.NewObject()
                                          .WithPhone(cellPhoneNumber, telephoneNumber)
                                          .DomainObject();

        Assert.False(customer.IsValid);
        Assert.NotEmpty(customer.GetErrors());
    }
}
