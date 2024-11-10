using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using SharedKernel;

namespace Application.Herois.Command.Update;

public class UpdateHeroiCommandHandler(
    IHeroisRepository heroisRepository,
    ISuperpoderRepository superpoderRepository)
    : ICommandHandler<UpdateHeroiCommand, UpdateHeroiDto>
{
    public async Task<Result<UpdateHeroiDto>> Handle(UpdateHeroiCommand command, CancellationToken cancellationToken)
    {
        Heroi heroiToUpdate = await heroisRepository.GetHeroiByIdAsync(command.Id, cancellationToken);

        if (heroiToUpdate == null)
        {
            return Result.Failure<UpdateHeroiDto>(HeroiErrors.NotFound);
        }

        bool success = await heroisRepository.CheckIfHeroiNomeExistsWithIdAsync(command.NomeHeroi, command.Id ,cancellationToken);

        if (success)
        {
            return Result.Failure<UpdateHeroiDto>(HeroiErrors.NomeHeroiAlreadyExists);
        }

        List<Superpoder> superpoderes = await superpoderRepository.GetAllSuperpoderes();

        List<Superpoder> heroiSuperpoderes = superpoderes.Where(s => command.SuperPoderesIds.Contains(s.Id)).ToList();

        heroiToUpdate.Update(command.Nome, command.NomeHeroi, command.Altura, command.Peso, command.DataNascimento);
            
        heroiToUpdate.UpdateSuperpoderes(heroiSuperpoderes);
        
        heroisRepository.Update(heroiToUpdate);
        
        await heroisRepository.SaveChangesAsync(cancellationToken);

        UpdateHeroiDto response = BuildResponse(heroiToUpdate);

        return response;
    }

    private UpdateHeroiDto BuildResponse(Heroi heroi)
    {
        return new UpdateHeroiDto(heroi.Id, heroi.Nome, heroi.NomeHeroi, heroi.DataNascimento!.Value, heroi.Altura,
            heroi.Peso, heroi.Superpoderes);
    }
}
