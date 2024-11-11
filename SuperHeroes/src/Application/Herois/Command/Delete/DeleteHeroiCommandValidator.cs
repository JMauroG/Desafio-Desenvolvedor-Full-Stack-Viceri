using Domain.HeroisAggregated.Errors;
using FluentValidation;

namespace Application.Herois.Command.Delete;

public class DeleteHeroiCommandValidator : AbstractValidator<DeleteHeroiCommand>
{
    public DeleteHeroiCommandValidator()
    {
        RuleFor(h => h.heroidId)
            .NotEmpty()
            .WithMessage(HeroiErrors.RequiredProperty("heroidId").Description)
            .WithErrorCode(HeroiErrors.RequiredPropertyCode);
        
        RuleFor(h => h.heroidId)
            .GreaterThan(0)
            .WithMessage(HeroiErrors.GreaterThan("heroidId", 0).Description)
            .WithErrorCode(HeroiErrors.GreaterThanCode);
    }
}
