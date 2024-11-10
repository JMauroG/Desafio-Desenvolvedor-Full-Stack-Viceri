using Application.Abstractions.Messaging;

namespace Application.Herois.Command.Update;

public record UpdateHeroiCommand(
    int Id,
    string Nome,
    string NomeHeroi,
    DateTime DataNascimento,
    float Altura,
    float Peso,
    List<int> SuperPoderesIds
) : ICommand<UpdateHeroiDto>;
