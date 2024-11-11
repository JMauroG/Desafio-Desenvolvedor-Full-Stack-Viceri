using System.Net;
using SharedKernel;

namespace Domain.HeroisAggregated.Errors;

public static class HeroiErrors
{
    public static Error TableEmpty => DomainErrors.TableEmpty("Herois", TableEmptyCode);
    public static Error NotFound => DomainErrors.NotFound(Heroi, NotFoundCode);
    public static Error AlreadyExists(string propertyName) => DomainErrors.AlreadyExists(propertyName, Heroi, AlreadyExistsCode);
    public static Error RequiredProperty(string property) => DomainErrors.RequiredProperty(property, RequiredPropertyCode);
    public static Error GreaterThan(string property, int value) => DomainErrors.GreaterThan(property, value, GreaterThanCode);

    public static string TableEmptyCode => $"001.{DomainErrors.TableEmptyCode}";
    public static string NotFoundCode => $"001.{DomainErrors.NotFoundCode}";
    public static string AlreadyExistsCode => $"001.{DomainErrors.AlreadyExistsCode}";
    public static string RequiredPropertyCode => $"001.{DomainErrors.RequiredPropertyCode}";
    public static string GreaterThanCode => $"001.{DomainErrors.GreaterThanCode}";
    
    private const string Heroi = "Herói";
}
