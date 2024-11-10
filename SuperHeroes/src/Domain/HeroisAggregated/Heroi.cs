using System.Data;

namespace Domain.HeroisAggregated;

public class Heroi
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string NomeHeroi { get; private set; }
    public DateTime? DataNascimento { get; private set; }
    public float Altura { get; private set; }
    public float Peso { get; private set; }

    public List<Superpoder> Superpoderes { get; private set; } = new List<Superpoder>();

    public Heroi()
    {
    }

    public Heroi(string nome, string nomeHeroi, DateTime dataNascimento, float altura, float peso, List<Superpoder>? superpoderes , int id = 0)
    {
        if (id != 0)
            Id = id;
        if (superpoderes != null && superpoderes!.Count != 0)
            Superpoderes = superpoderes;
        Nome = nome;
        NomeHeroi = nomeHeroi;
        DataNascimento = dataNascimento;
        Altura = altura;
        Peso = peso;
    }

    public void Update(string nome, string nomeHeroi, float altura, float peso, DateTime dataNascimento)
    {
        Nome = nome;
        NomeHeroi = nomeHeroi;
        Altura = altura;
        Peso = peso;
        DataNascimento = dataNascimento;
    }

    public void UpdateSuperpoderes(List<Superpoder> superpoderes)
    {
        Superpoderes = superpoderes;
    }
}
