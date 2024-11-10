using System.Text.Json.Serialization;

namespace Domain.HeroisAggregated;

public class Superpoder
{
    public int Id { get; set; }
    public string Descricao { get; private set; }
    public string Poder { get; private set; }
    [JsonIgnore]
    public List<Heroi> Herois { get; set; } = new List<Heroi>();

    public Superpoder()
    {
    }

    public Superpoder(string descricao, string poder)
    {
        Descricao = descricao;
        Poder = poder;
    }
    
    public Superpoder(int id, string descricao, string poder)
    {
        Id = id;
        Descricao = descricao;
        Poder = poder;
    }
}
