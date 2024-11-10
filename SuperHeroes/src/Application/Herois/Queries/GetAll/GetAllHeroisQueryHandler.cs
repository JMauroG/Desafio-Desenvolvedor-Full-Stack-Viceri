using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using SharedKernel;

namespace Application.Herois.Queries.GetAll;

public class GetAllHeroisQueryHandler(IHeroisRepository heroisRepository)
    : IQueryHandler<GetAllHeroisQuery, List<GetAllHeroisDto>>
{
    public async Task<Result<List<GetAllHeroisDto>>> Handle(GetAllHeroisQuery query,
        CancellationToken cancellationToken)
    {
        List<Heroi> herois = await heroisRepository.GetAllHeroisReadOnlyAsync(cancellationToken);

        if (herois.Count == 0)
        {
            return Result.Failure<List<GetAllHeroisDto>>(HeroiErrors.TableEmpty);
        }

        List<GetAllHeroisDto> response = herois.Select(heroi => new GetAllHeroisDto(heroi.Id, heroi.Nome, heroi.NomeHeroi, heroi.DataNascimento!.Value, heroi.Altura,
            heroi.Peso, heroi.Superpoderes)).ToList();

        return response;
    }
}
