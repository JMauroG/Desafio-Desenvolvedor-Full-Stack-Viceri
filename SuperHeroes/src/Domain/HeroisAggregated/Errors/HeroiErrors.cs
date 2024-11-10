using System.Net;
using SharedKernel;

namespace Domain.HeroisAggregated.Errors;

public static class HeroiErrors
{
    public static Error TableEmpty => new(code: TableEmptyCode,
        description: "Não há heróis na base de dados",
        HttpStatusCode.NotFound);

    public static Error NotFound => new(code: NotFoundCode,
        description: "Herói não encontrado",
        HttpStatusCode.NotFound);

    public static Error NomeHeroiAlreadyExists => new(code: NomeHeroiAlreadyExistsCode,
        description: "Nome de herói já cadastrado",
        HttpStatusCode.BadRequest);

    public static Error NomeRequired => new(code: NomeRequiredCode, description: "É necessário informar um nome",
        HttpStatusCode.BadRequest);

    public static Error NomeHeroiRequired => new(code: NomeHeroiRequiredCode,
        description: "É necessário informar um nome de heroi",
        HttpStatusCode.BadRequest);
    
    public static Error AlturaRequired => new(code: AlturaRequiredCode,
        description: "É necessário informar a altura do heroi",
        HttpStatusCode.BadRequest);
    
    public static Error PesoRequired => new(code: PesoRequiredCode,
        description: "É necessário informar o peso do heroi",
        HttpStatusCode.BadRequest);
    
    public static Error SuperpoderesIdsRequired => new(code: SuperpoderesIdsRequiredCode,
        description: "É necessário informar os poderes do heroi",
        HttpStatusCode.BadRequest);
    
    public static Error HeroiIdRequired => new(code: HeroiIdRequiredCode,
        description: "É necessário informar o identificador do heroi",
        HttpStatusCode.BadRequest);


    public static string TableEmptyCode => "001";
    public static string NotFoundCode => "002";
    public static string NomeHeroiAlreadyExistsCode => "003";
    public static string NomeRequiredCode => "004";
    public static string NomeHeroiRequiredCode => "005";
    public static string AlturaRequiredCode => "006";
    public static string PesoRequiredCode => "007";
    public static string SuperpoderesIdsRequiredCode => "008";
    public static string HeroiIdRequiredCode => "009";
}
