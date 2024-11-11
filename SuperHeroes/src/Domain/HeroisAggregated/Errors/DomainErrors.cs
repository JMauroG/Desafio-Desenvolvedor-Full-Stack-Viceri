using System.Net;
using SharedKernel;

namespace Domain.HeroisAggregated.Errors;

public static class DomainErrors
{
    public static Error TableEmpty(string entity, string entityCodeError) => new(
        code: entityCodeError,
        description: $"{entity} não existem na base de dados",
        HttpStatusCode.NotFound);

    public static Error NotFound(string entity, string entityCodeError) => new(
        code: entityCodeError,
        description: $"{entity} não encontrado(a)",
        HttpStatusCode.NotFound);

    public static Error AlreadyExists(string property, string entity, string entityCodeError) => new(
        code: entityCodeError,
        description: $"{property} já existe para este(a) {entity}",
        HttpStatusCode.NotFound
    );
    
    public static Error RequiredProperty(string property, string entityCodeError) => new(
        code: entityCodeError,
        description: $"{property} é obrigatório(a)",
        HttpStatusCode.BadRequest
    );
    
    public static Error GreaterThan(string property, int value, string entityCodeError) => new(
        code: entityCodeError,
        description: $"{property} deve ser maior que {value}",
        HttpStatusCode.BadRequest
    );
    
    
    public static string TableEmptyCode => $"{(int)DomainErrorCodes.TableEmpty:D3}";
    public static string NotFoundCode => $"{(int)DomainErrorCodes.NotFound:D3}";
    
    public static string AlreadyExistsCode => $"{(int)DomainErrorCodes.AlreadyExists:D3}";
    public static string RequiredPropertyCode => $"{(int)DomainErrorCodes.RequiredProperty:D3}";
    public static string GreaterThanCode => $"{(int)DomainErrorCodes.GreaterThan:D3}";
}
public enum DomainErrorCodes
{
    TableEmpty = 1,
    NotFound = 2,
    AlreadyExists = 3,
    RequiredProperty = 4,
    GreaterThan = 5
}
