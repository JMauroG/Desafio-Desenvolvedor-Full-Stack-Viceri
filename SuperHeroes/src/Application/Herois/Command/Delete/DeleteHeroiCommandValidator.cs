using Domain.HeroisAggregated.Errors;
using FluentValidation;

namespace Application.Herois.Command.Delete;

public class DeleteHeroiCommandValidator : AbstractValidator<DeleteHeroiCommand>
{
    public DeleteHeroiCommandValidator()
    {
        RuleFor(h => h.heroidId)
            .NotNull()
            .NotEmpty()
            .WithMessage(HeroiErrors.HeroiIdRequired.Description)
            .WithErrorCode(HeroiErrors.NomeRequiredCode);
    }
}
