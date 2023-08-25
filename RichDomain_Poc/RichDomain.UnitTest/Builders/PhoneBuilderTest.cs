using RichDomain.API.Business.Domain.ValueObjects;

namespace RichDomain.UnitTest.Builders;
public sealed class PhoneBuilderTest
{
    private string _cellPhoneNumber = "11910775566";
    private string? _telephoneNumber = "1133715562";

    public static PhoneBuilderTest NewObject() => new();

    public Phone DomainObject() =>
        new(_cellPhoneNumber,
            _telephoneNumber);

    public PhoneBuilderTest WithCellPhoneNumber(string cellPhoneNumber)
    {
        _cellPhoneNumber = cellPhoneNumber;
        return this;
    }

    public PhoneBuilderTest WithTelephoneNumber(string? telephoneNumber)
    {
        _telephoneNumber = telephoneNumber;
        return this;
    }


}
