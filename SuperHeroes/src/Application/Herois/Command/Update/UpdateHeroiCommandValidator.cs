using Domain.HeroisAggregated.Errors;
using FluentValidation;

namespace Application.Herois.Command.Update;

public class UpdateHeroiCommandValidator : AbstractValidator<UpdateHeroiCommand>
{
    public UpdateHeroiCommandValidator()
    {
        RuleFor(h => h.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(HeroiErrors.HeroiIdRequired.Description)
            .WithErrorCode(HeroiErrors.NomeRequiredCode);
        RuleFor(h => h.Nome)
            .NotEmpty()
            .WithMessage(HeroiErrors.NomeRequired.Description)
            .WithErrorCode(HeroiErrors.NomeRequiredCode);
        
        RuleFor(h => h.NomeHeroi)
            .NotEmpty()
            .WithMessage(HeroiErrors.NomeHeroiRequired.Description)
            .WithErrorCode(HeroiErrors.NomeHeroiRequiredCode);

        RuleFor(h => h.Altura)
            .NotNull()
            .NotEmpty()
            .WithMessage(HeroiErrors.AlturaRequired.Description)
            .WithErrorCode(HeroiErrors.AlturaRequiredCode);
        
        RuleFor(h => h.Peso)
            .NotNull()
            .NotEmpty()
            .WithMessage(HeroiErrors.PesoRequired.Description)
            .WithErrorCode(HeroiErrors.PesoRequiredCode);
        
        RuleFor(h => h.SuperPoderesIds)
            .NotEmpty()
            .WithMessage(HeroiErrors.SuperpoderesIdsRequired.Description)
            .WithErrorCode(HeroiErrors.SuperpoderesIdsRequiredCode);
    }
}
