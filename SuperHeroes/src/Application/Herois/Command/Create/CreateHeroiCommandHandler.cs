using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using SharedKernel;

namespace Application.Herois.Command.Create;

public sealed class CreateHeroiCommandHandler(
    IHeroisRepository heroisRepository,
    ISuperpoderRepository superpoderRepository)
    : ICommandHandler<CreateHeroiCommand, CreateHeroiDto>
{
    public async Task<Result<CreateHeroiDto>> Handle(CreateHeroiCommand command, CancellationToken cancellationToken)
    {
        if (await heroisRepository.CheckIfHeroiNomeExistsAsync(command.NomeHeroi,cancellationToken))
        {
            return Result.Failure<CreateHeroiDto>(HeroiErrors.NomeHeroiAlreadyExists);
        }

        List<Superpoder> superpoderes = await superpoderRepository.GetAllSuperpoderes();

        Heroi heroi = new Heroi(nome: command.Nome, nomeHeroi: command.NomeHeroi,
            dataNascimento: command.DataNascimento!.Value, altura: command.Altura!.Value, peso: command.Peso!.Value,
            superpoderes.Where(s => command.SuperpoderesIds.Contains(s.Id)).ToList());

        await heroisRepository.AddAsync(heroi,cancellationToken);

        await heroisRepository.SaveChangesAsync(cancellationToken);

        CreateHeroiDto response = BuildResponse(heroi);

        return response;
    }

    private  CreateHeroiDto BuildResponse(Heroi heroi)
    {
        CreateHeroiDto response = new CreateHeroiDto(heroi.Id, heroi.Nome, heroi.NomeHeroi, heroi.DataNascimento!.Value,
            heroi.Altura, heroi.Peso, heroi.Superpoderes);

        return response;
    }
}
