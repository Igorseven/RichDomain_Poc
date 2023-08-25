using RichDomain.API.Business.Domain.Extensions;

namespace RichDomain.API.Business.Domain.ValueObjects;

public class Phone
{
    public string CellPhoneNumber { get; private set; } = string.Empty;
    public string? TelephoneNumber { get; private set; }

    private Phone()
    {
        
    }

    public Phone(string cellPhoneNumber, string? telephoneNumber)
    {
        this.CellPhoneNumber = cellPhoneNumber.RemoveCaracters();
        this.TelephoneNumber = telephoneNumber?.RemoveCaracters();
    }
}

