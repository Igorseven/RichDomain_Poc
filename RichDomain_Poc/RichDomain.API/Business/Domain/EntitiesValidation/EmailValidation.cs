using FluentValidation;
using RichDomain.API.Business.Domain.Entities;
using RichDomain.API.Business.Domain.Enums;
using RichDomain.API.Business.Domain.Extensions;

namespace RichDomain.API.Business.Domain.EntitiesValidation;
public sealed class EmailValidation : AbstractValidator<Email>
{
    public EmailValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(e => e.EmailAddress).EmailAddress().Length(7, 150)
            .WithMessage(e => !string.IsNullOrWhiteSpace(e.EmailAddress)
            ? EMessage.MoreExpected.GetDescription().FormatTo("E-mail", "entre {MinLength} e {MaxLength}")
            : EMessage.Required.GetDescription().FormatTo("E-mail"));
    }
}
