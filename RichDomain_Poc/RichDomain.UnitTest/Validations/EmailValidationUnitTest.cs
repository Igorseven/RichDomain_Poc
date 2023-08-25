using Bogus.Extensions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using RichDomain.UnitTest.Builders;

namespace RichDomain.UnitTest.Validations;
public sealed class EmailValidationUnitTest
{
    [Fact]
    [Trait("Success", "Perfect setting")]
    public void EmailValidation_PerfectSetting_IsValid()
    {
        var email = EmailBuilderTest.NewObject()
                                    .DomainObject();

        Assert.True(email.IsValid);
        Assert.Empty(email.GetErrors());
    }

    public static IEnumerable<object[]> InvalidEmail()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Person.Email.ClampLength(1, 6)},
            new object[] {new Bogus.Faker().Person.Email.ClampLength(151, 155)},
            new object[] {new Bogus.Faker().Person.FirstName.ClampLength(8, 10)},
            new object[] {"user.hotmail.com"},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Perfect setting")]
    [MemberData(nameof(InvalidEmail))]
    public void EmailValidation_InvalidEmail_Invalid(string emailAddress)
    {
        var email = EmailBuilderTest.NewObject()
                                    .WithEmailAddress(emailAddress)
                                    .DomainObject();

        Assert.False(email.IsValid);
        Assert.NotEmpty(email.GetErrors());
    }
}
