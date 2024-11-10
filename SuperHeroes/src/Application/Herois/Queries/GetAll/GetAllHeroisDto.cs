using Domain.HeroisAggregated;

namespace Application.Herois.Queries.GetAll;

public record GetAllHeroisDto(
    int Id,
    string Nome,
    string NomeHeroi,
    DateTime DataNascimento,
    float Altura,
    float Peso,
    List<Superpoder> Superpoderes
    );
