using FluentValidation;
using FluentValidation.Results;
using RichDomain.API.Business.Domain.Extensions;

namespace RichDomain.API.Business.Domain.Entities.Base;

public abstract class EntityBase
{
    public DateTime CreateDate { get; set; }
    public bool IsValid => GetErrors().Count == 0;
    private ValidationResult? _validation { get; set; }

    public Dictionary<string, string> GetErrors() => _validation!.Errors.ToDictionary();

    protected bool Validate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
    {
        _validation = validator.Validate(entity);

        return IsValid;
    }

}
