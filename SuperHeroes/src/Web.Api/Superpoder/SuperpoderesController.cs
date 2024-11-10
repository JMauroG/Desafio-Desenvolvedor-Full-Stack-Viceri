using Application.Superpoderes.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Extensions;

namespace Web.Api.Superpoder;

public class SuperpoderesController(ISender sender) : ApiBaseController(sender)
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAllSuperpoderesDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    public async Task<ActionResult> GetAllSuperpoderes()
    {
        GetAllSuperpoderesQuery query = new();


        Result<List<GetAllSuperpoderesDto>> result = await _sender.Send(query);

        return result.Match(
            onSuccess: () => Ok(result.Value),
            onFailure: HandleFailure
        );
    }
}
