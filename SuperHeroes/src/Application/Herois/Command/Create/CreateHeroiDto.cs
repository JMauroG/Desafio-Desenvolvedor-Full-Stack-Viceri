using Domain.HeroisAggregated;

namespace Application.Herois.Command.Create;

public record CreateHeroiDto(
    int Id,
    string Nome,
    string NomeHeroi,
    DateTime DataNascimento,
    float Altura,
    float Peso,
    List<Superpoder> Superpoderes
);
