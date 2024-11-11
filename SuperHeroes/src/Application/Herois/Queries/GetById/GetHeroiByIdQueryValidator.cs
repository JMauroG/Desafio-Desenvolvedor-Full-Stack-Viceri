using Domain.HeroisAggregated.Errors;
using FluentValidation;

namespace Application.Herois.Queries.GetById;

public class GetHeroiByIdQueryValidator : AbstractValidator<GetHeroiByIdQuery>
{
    public GetHeroiByIdQueryValidator()
    {
        RuleFor(h => h.Id)
            .NotEmpty()
            .WithMessage(HeroiErrors.RequiredProperty("Id").Description)
            .WithErrorCode(HeroiErrors.RequiredPropertyCode);
        
        RuleFor(h => h.Id)
            .GreaterThan(0)
            .When(h => h.Id.HasValue)
            .WithMessage(HeroiErrors.GreaterThan("Id", 0).Description)
            .WithErrorCode(HeroiErrors.GreaterThanCode);
    }
}
