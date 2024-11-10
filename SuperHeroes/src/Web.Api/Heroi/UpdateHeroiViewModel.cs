namespace Web.Api.Heroi;

public record UpdateHeroiViewModel(
    int? Id,
    string Nome,
    string NomeHeroi,
    DateTime? DataNascimento,
    float? Altura,
    float? Peso,
    List<int> SuperPoderesIds
);
