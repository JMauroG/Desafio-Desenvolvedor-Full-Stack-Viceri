using System.Net;
using FluentValidation;
using MediatR;
using SharedKernel;

namespace Application.Abstractions.Behaviors;

//Verifica se tem um validator antes de passar para o Handler
//Recuperar os errors gerados pelos IValidor, transforma os validationsFaliures em "Error" e retorna um ValidationReult com os errors tratados
internal sealed class ValidationPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TResponse : Result
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        Error[] errorList = _validators
            .Select( validator => validator.Validate(request))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => new Error(failure.ErrorCode, failure.ErrorMessage, HttpStatusCode.BadRequest))
            .ToArray();

        if (errorList.Any())
            return CreateValidateResult<TResponse>(errorList);

        return await next();
    }

    private static TResult CreateValidateResult<TResult>(Error[] errorList) where TResult : Result
    {
        if(typeof(TResult) == typeof(Result))
            return ValidationResult.WithErrors(errorList) as TResult;

        var validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            .GetMethod(nameof(ValidationResult.WithErrors))!
            .Invoke(null, [errorList]);
        
        return (TResult)validationResult;
    }
}
