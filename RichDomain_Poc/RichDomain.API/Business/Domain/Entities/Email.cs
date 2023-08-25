using RichDomain.API.Business.Domain.Entities.Base;
using RichDomain.API.Business.Domain.EntitiesValidation;

namespace RichDomain.API.Business.Domain.Entities;

public class Email : EntityBase
{
    public int EmailId { get; private set; }
    public string EmailAddress { get; private set; } = string.Empty;
    public int CustomerId { get; private set; }

    private Email()
    {

    }

    public Email(string emailAddress)
    {
        this.EmailAddress = emailAddress;

        this.Validate(this, new EmailValidation());
    }

    public Email(string emailAddress, int customerId)
    {
        this.EmailAddress = emailAddress;
        this.CustomerId = customerId;

        this.Validate(this, new EmailValidation());
    }

    public void UpdateEmailAddress(string emailAddress)
    {
        this.EmailAddress = emailAddress;

        this.Validate(this, new EmailValidation());
    }
}
