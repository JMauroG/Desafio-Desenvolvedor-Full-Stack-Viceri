using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using FluentValidation;

namespace Application.Herois.Command.Create;

public class CreateHeroiCommandValidator: AbstractValidator<CreateHeroiCommand>
{
    public CreateHeroiCommandValidator()
    {
        RuleFor(h => h.Nome)
            .NotEmpty()
            .WithMessage(HeroiErrors.RequiredProperty("Nome").Description)
            .WithErrorCode(HeroiErrors.RequiredPropertyCode);
        
        RuleFor(h => h.NomeHeroi)
            .NotEmpty()
            .WithMessage(HeroiErrors.RequiredProperty("NomeHeroi").Description)
            .WithErrorCode(HeroiErrors.RequiredPropertyCode);

        RuleFor(h => h.Altura)
            .NotEmpty()
            .WithMessage(HeroiErrors.RequiredProperty("Altura").Description)
            .WithErrorCode(HeroiErrors.RequiredPropertyCode);
        
        RuleFor(h => h.Altura)
            .GreaterThan(0)
            .When(h => h.Altura.HasValue)
            .WithMessage(HeroiErrors.GreaterThan("Altura", 0).Description)
            .WithErrorCode(HeroiErrors.GreaterThanCode);
        
        RuleFor(h => h.Peso)
            .NotEmpty()
            .WithMessage(HeroiErrors.RequiredProperty("Peso").Description)
            .WithErrorCode(HeroiErrors.RequiredPropertyCode);
        
        RuleFor(h => h.Peso)
            .GreaterThan(0)
            .When(h => h.Peso.HasValue)
            .WithMessage(HeroiErrors.GreaterThan("Peso", 0).Description)
            .WithErrorCode(HeroiErrors.GreaterThanCode);
        
        RuleFor(h => h.SuperpoderesIds)
            .NotEmpty()
            .WithMessage(HeroiErrors.RequiredProperty("SuperpoderesIds").Description)
            .WithErrorCode(HeroiErrors.RequiredPropertyCode);
    }
}
