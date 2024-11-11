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
        Heroi heroi = await heroisRepository.GetHeroiByIdAsync(command.Id!.Value, cancellationToken);

        if (heroi == null)
            return Result.Failure<UpdateHeroiDto>(HeroiErrors.NotFound);

        bool success =
            await heroisRepository.CheckIfHeroiNomeExistsWithIdAsync(command.NomeHeroi!, command.Id!.Value,
                cancellationToken);

        if (success)
            return Result.Failure<UpdateHeroiDto>(HeroiErrors.NomeHeroiAlreadyExists);

        List<Superpoder> heroiSuperpoderes = await superpoderRepository.GetSuperpoderesListFromIdListAsync(command.SuperPoderesIds, cancellationToken);

        heroi.Update(command.Nome, command.NomeHeroi!, command.Altura, command.Peso, command.DataNascimento);
        heroi.UpdateSuperpoderes(heroiSuperpoderes);

        heroisRepository.Update(heroi);
        await heroisRepository.SaveChangesAsync(cancellationToken);

        UpdateHeroiDto response = BuildResponse(heroi, heroiSuperpoderes);

        return response;
    }

    private UpdateHeroiDto BuildResponse(Heroi heroi, List<Superpoder> superpoderes)
    {
        return new UpdateHeroiDto(heroi.Id, heroi.Nome, heroi.NomeHeroi, heroi.DataNascimento!.Value, heroi.Altura,
            heroi.Peso, superpoderes);
    }
}
