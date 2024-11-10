using System.Net;

namespace SharedKernel;

public record Error
{
    public static readonly Error None = new(string.Empty, String.Empty, HttpStatusCode.OK);
    public static readonly Error NullValue = new(String.Empty, string.Empty, HttpStatusCode.InternalServerError);
    public Error(string code, string description, HttpStatusCode statusCode)
    {
        Code = code;
        Description = description;
        StatusCode = statusCode;
    }

    public string Code { get; }

    public string Description { get; }

    public HttpStatusCode StatusCode { get; set; }
}
