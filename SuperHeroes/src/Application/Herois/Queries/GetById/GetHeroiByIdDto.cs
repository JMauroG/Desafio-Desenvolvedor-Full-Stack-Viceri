using Domain.HeroisAggregated;

namespace Application.Herois.Queries.GetById;

public record GetHeroiByIdDto(
    int Id,
    string Nome,
    string NomeHeroi,
    DateTime DataNascimento,
    float Altura,
    float Peso,
    List<Superpoder> Superpoderes
);
