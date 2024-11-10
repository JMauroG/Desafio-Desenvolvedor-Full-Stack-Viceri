using Application.Abstractions.Messaging;
using Domain.HeroisAggregated;

namespace Application.Herois.Command.Create;

public sealed record CreateHeroiCommand(
    string Nome,
    string NomeHeroi,
    DateTime? DataNascimento,
    float? Altura,
    float? Peso,
    List<int> SuperpoderesIds
) : ICommand<CreateHeroiDto>;
