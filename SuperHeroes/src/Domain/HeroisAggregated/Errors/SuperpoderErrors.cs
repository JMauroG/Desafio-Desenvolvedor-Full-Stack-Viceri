using System.Net;
using SharedKernel;

namespace Domain.HeroisAggregated.Errors;

public static class SuperpoderErrors
{
    public static Error TableEmpty => new Error(code: "404",
        description: "Não há superpoderes na base de dados",
        HttpStatusCode.NotFound
    );
}
