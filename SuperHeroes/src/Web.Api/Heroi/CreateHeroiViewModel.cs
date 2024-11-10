using System.ComponentModel.DataAnnotations;

namespace Web.Api.Heroi;

public sealed record CreateHeroiViewModel(
    string Nome,
    string NomeHeroi,
    DateTime? DataNascimento,
    float? Altura,
    float? Peso,
    List<int> SuperpoderesIds
);
