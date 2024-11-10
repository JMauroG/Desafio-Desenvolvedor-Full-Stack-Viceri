using System.Net;
using MediatR;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web.Api;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class ApiBaseController(ISender sender) : ControllerBase
{
    protected readonly ISender _sender = sender;

    protected ObjectResult HandleFailure(Error[] errorList)
    {
        return errorList.Length == 1 ? HandleSingleFailure(errorList[0]) : BadRequest(errorList);
    }

    private ObjectResult HandleSingleFailure(Error error)
    {
        return error.StatusCode switch
        {
            HttpStatusCode.BadRequest => BadRequest(error),
            HttpStatusCode.NotFound => NotFound(error),
            HttpStatusCode.InternalServerError => StatusCode(500, error),
            _ => BadRequest(error)
        };
    }
}
