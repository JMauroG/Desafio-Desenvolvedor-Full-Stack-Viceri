using Domain.HeroisAggregated;

namespace Application.Herois.Command.Update;

public record UpdateHeroiDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? NomeHeroi { get; set; }
    public DateTime? DataNascimento { get; set; }
    public float? Altura { get; set; }
    public float? Peso { get; set; }
    public List<Superpoder>? Superpoderes { get; set; }

    public UpdateHeroiDto(Heroi heroi)
    {
        Id = heroi.Id;
        Nome = heroi.Nome;
        NomeHeroi = heroi.NomeHeroi;
        DataNascimento = heroi.DataNascimento;
        Altura = heroi.Altura;
        Peso = heroi.Peso;
        Superpoderes = heroi.Superpoderes;
    }

    public UpdateHeroiDto(
        int id,
        string? nome,
        string? nomeHeroi,
        DateTime? dataNascimento,
        float? altura,
        float? peso,
        List<Superpoder>? superpoderes)
    {
        Id = id;
        Nome = nome;
        NomeHeroi = nomeHeroi;
        DataNascimento = dataNascimento;
        Altura = altura;
        Peso = peso;
        Superpoderes = superpoderes;
    }
}
