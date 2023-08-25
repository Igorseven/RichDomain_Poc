using FluentValidation;
using RichDomain.API.Business.Domain.Enums;
using RichDomain.API.Business.Domain.Extensions;
using RichDomain.API.Business.Domain.ValueObjects;

namespace RichDomain.API.Business.Domain.EntitiesValidation;
public sealed class PhoneValidation : AbstractValidator<Phone>
{
    public PhoneValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(p => p.TelephoneNumber).NotEmpty().Length(10, 12)
            .WithMessage(p => string.IsNullOrWhiteSpace(p.TelephoneNumber)
            ? EMessage.Required.GetDescription().FormatTo("Número de telefone")
            : EMessage.MoreExpected.GetDescription().FormatTo("Número de telefone", "entre {MinLength} e {MaxLength}"));

        When(p => p.TelephoneNumber is not null, () =>
        {
            RuleFor(p => p.CellPhoneNumber).NotEmpty().Length(11, 14)
                .WithMessage(p => string.IsNullOrWhiteSpace(p.CellPhoneNumber)
                ? EMessage.Required.GetDescription().FormatTo("Número do celular")
                : EMessage.MoreExpected.GetDescription().FormatTo("Número do celular", "entre {MinLength} e {MaxLength}"));
        });
        
    }
}
