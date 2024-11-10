using Domain.HeroisAggregated.Errors;
using FluentValidation;

namespace Application.Herois.Queries.GetById;

public class GetHeroiByIdQueryValidator : AbstractValidator<GetHeroiByIdQuery>
{
    public GetHeroiByIdQueryValidator()
    {
        RuleFor(h => h.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(HeroiErrors.HeroiIdRequired.Description)
            .WithErrorCode(HeroiErrors.NomeRequiredCode);
    }
}
