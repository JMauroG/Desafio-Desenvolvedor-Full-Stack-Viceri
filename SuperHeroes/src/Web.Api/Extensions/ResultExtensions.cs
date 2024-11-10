using SharedKernel;

namespace Web.Api.Extensions;

public static class ResultExtensions
{
    public static TOutput Match<T, TOutput>(
        this Result<T> result,
        Func<TOutput> onSuccess,
        Func<Error[], TOutput> onFailure
    )
    {
        var resultType = result.GetType();
        var resultTypeIsValidationResult = resultType == typeof(ValidationResult<T>);

        if (!resultTypeIsValidationResult)
        {
            return result.IsSuccess ? onSuccess() : onFailure([result.Error]);
        }

        ValidationResult<T> validationResult = (ValidationResult<T>)result;
        return validationResult.IsSuccess ? onSuccess() : onFailure(validationResult.Errors);
    }
}
