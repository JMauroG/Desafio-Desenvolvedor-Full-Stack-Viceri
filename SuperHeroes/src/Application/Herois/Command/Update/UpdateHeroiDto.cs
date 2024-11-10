using Domain.HeroisAggregated;

namespace Application.Herois.Command.Update;

public record UpdateHeroiDto(
    int Id,
    string Nome,
    string NomeHeroi,
    DateTime DataNascimento,
    float Altura,
    float Peso,
    List<Superpoder> Superpoderes
    );
