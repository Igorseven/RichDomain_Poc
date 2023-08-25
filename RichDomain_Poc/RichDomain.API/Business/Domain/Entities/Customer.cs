using RichDomain.API.Business.Domain.Entities.Base;
using RichDomain.API.Business.Domain.EntitiesValidation;
using RichDomain.API.Business.Domain.Enums;
using RichDomain.API.Business.Domain.ValueObjects;

namespace RichDomain.API.Business.Domain.Entities;

public class Customer : EntityBase
{
    public int CustomerId { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public ECustomerType CustomerType { get; private set; } = ECustomerType.Active;
    public Email? Email { get; private set; }
    public Phone? Phone { get; private set; }

    private Customer()
    {
        
    }

    public Customer(string firstName, string lastName, ECustomerType customerType, Email email, Phone phone)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.CustomerType = customerType;
        this.Email = email;
        this.Phone = phone;

        this.Validate(this, new CustomerValidation());
    }

    public void CustomerUpdate(string firstName, string lastName, Phone phone)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Phone = phone;

        this.Validate(this, new CustomerValidation());
    }

    public void CustomerTypeUpdate(ECustomerType customerType) => this.CustomerType = customerType;
}
