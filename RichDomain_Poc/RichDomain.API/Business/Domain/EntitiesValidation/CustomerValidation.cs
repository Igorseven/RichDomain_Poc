using FluentValidation;
using RichDomain.API.Business.Domain.Entities;
using RichDomain.API.Business.Domain.Enums;
using RichDomain.API.Business.Domain.Extensions;

namespace RichDomain.API.Business.Domain.EntitiesValidation;
public sealed class CustomerValidation : AbstractValidator<Customer>
{
    public CustomerValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(c => c.Phone).SetValidator(new PhoneValidation()!);
        RuleFor(c => c.Email).SetValidator(new EmailValidation()!);

        RuleFor(c => c.FirstName).NotEmpty().Length(3, 70)
            .WithMessage(c => string.IsNullOrWhiteSpace(c.FirstName)
            ? EMessage.Required.GetDescription().FormatTo("Primeiro nome")
            : EMessage.MoreExpected.GetDescription().FormatTo("Primeiro nome", "entre {MinLength} e {MaxLength}"));

        RuleFor(c => c.LastName).NotEmpty().Length(3, 70)
            .WithMessage(c => string.IsNullOrWhiteSpace(c.LastName)
            ? EMessage.Required.GetDescription().FormatTo("Sobrenome")
            : EMessage.MoreExpected.GetDescription().FormatTo("Sobrenome", "entre {MinLength} e {MaxLength}"));
    }

}
