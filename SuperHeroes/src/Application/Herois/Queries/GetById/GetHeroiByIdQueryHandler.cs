using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Herois.Queries.GetAll;
using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using SharedKernel;

namespace Application.Herois.Queries.GetById;

public class GetHeroiByIdQueryHandler(IHeroisRepository heroisRepository)
    : IQueryHandler<GetHeroiByIdQuery, GetHeroiByIdDto>
{
    public async Task<Result<GetHeroiByIdDto>> Handle(GetHeroiByIdQuery query, CancellationToken cancellationToken)
    {
        Heroi heroi = await heroisRepository.GetHeroiByIdReadOnlyAsync(query.Id, cancellationToken);

        if (heroi == null)
        {
            return Result.Failure<GetHeroiByIdDto>(HeroiErrors.NotFound);
        }

        GetHeroiByIdDto response = new GetHeroiByIdDto(heroi.Id, heroi.Nome, heroi.NomeHeroi, heroi.DataNascimento!.Value,
            heroi.Altura, heroi.Peso, heroi.Superpoderes);

        return response;
    }
}
