using System.Net;

namespace SharedKernel;

public interface IValidationResult
{
    public static readonly Error ValidationError =
        new("400", "Ocorreu um error de validação", HttpStatusCode.BadRequest);

    Error[] Errors { get; }
}
