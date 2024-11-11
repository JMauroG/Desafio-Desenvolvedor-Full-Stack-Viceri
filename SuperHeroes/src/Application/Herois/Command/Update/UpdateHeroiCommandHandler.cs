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
            return Result.Failure<UpdateHeroiDto>(HeroiErrors.AlreadyExists("NomeHeroi"));

        List<Superpoder> heroiSuperpoderes = await superpoderRepository.GetSuperpoderesListFromIdListAsync(command.SuperPoderesIds!, cancellationToken);

        heroi.Update(command.Nome!, command.NomeHeroi!, command.Altura!.Value, command.Peso!.Value, command.DataNascimento!.Value);
        heroi.UpdateSuperpoderes(heroiSuperpoderes);

        heroisRepository.Update(heroi);
        await heroisRepository.SaveChangesAsync(cancellationToken);

        UpdateHeroiDto response = new (heroi);

        return response;
    }
}
