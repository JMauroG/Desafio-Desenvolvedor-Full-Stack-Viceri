using Application.Herois.Command.Create;
using Application.Herois.Command.Delete;
using Application.Herois.Command.Update;
using Application.Herois.Queries.GetAll;
using Application.Herois.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SharedKernel;
using Web.Api.Extensions;

namespace Web.Api.Heroi;

public class HeroisController(ISender sender) : ApiBaseController(sender)
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateHeroiDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
    public async Task<IActionResult> CreateHeroiAsync([FromBody] CreateHeroiViewModel model)
    {
        CreateHeroiCommand command = new(model.Nome, model.NomeHeroi, model.DataNascimento, model.Altura,
            model.Peso, model.SuperpoderesIds);

        Result<CreateHeroiDto> result = await _sender.Send(command);

        return result.Match(
            onSuccess: () => Ok(result.Value),
            onFailure: HandleFailure
        );
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    public async Task<IActionResult> DeleteHeroiAsync([FromQuery] int heroiId)
    {
        DeleteHeroiCommand command = new(heroiId);

        Result<string> result = await _sender.Send(command);

        return result.Match(
            onSuccess: () => Ok(result.Value),
            onFailure: HandleFailure
        );
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateHeroiDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    public async Task<IActionResult> UpdateHeroi([FromBody] UpdateHeroiViewModel model)
    {
        UpdateHeroiCommand command = new(model.Id!.Value, model.Nome, model.NomeHeroi, model.DataNascimento!.Value, model.Altura!.Value,
            model.Peso!.Value, model.SuperPoderesIds);

        Result<UpdateHeroiDto> result = await _sender.Send(command);

        return result.Match(
            onSuccess: () => Ok(result.Value),
            onFailure: HandleFailure
        );
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAllHeroisDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    public async Task<IActionResult> GetHeroisAsync()
    {
        GetAllHeroisQuery query = new();

        Result<List<GetAllHeroisDto>> result = await _sender.Send(query);

        return result.Match(
            onSuccess: () => Ok(result.Value),
            onFailure: HandleFailure
        );
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetHeroiByIdDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    public async Task<IActionResult> GetHeroisByIdAsync(int id)
    {
        GetHeroiByIdQuery query = new(id);

        Result<GetHeroiByIdDto> result = await _sender.Send(query);

        return result.Match(
            onSuccess: () => Ok(result.Value),
            onFailure: HandleFailure
        );
    }
}
