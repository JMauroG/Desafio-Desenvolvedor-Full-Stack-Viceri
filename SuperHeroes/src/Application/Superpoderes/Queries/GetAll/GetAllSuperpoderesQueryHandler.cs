using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using SharedKernel;

namespace Application.Superpoderes.Queries.GetAll;

public class GetAllSuperpoderesQueryHandler(ISuperpoderRepository superpoderRepository)
    : IQueryHandler<GetAllSuperpoderesQuery, List<GetAllSuperpoderesDto>>
{
    public async Task<Result<List<GetAllSuperpoderesDto>>> Handle(GetAllSuperpoderesQuery request,
        CancellationToken cancellationToken)
    {
        List<Superpoder> superpoders = await superpoderRepository.GetAllSuperpoderesAsync(cancellationToken);

        if (superpoders.Count == 0)
        {
            return Result.Failure<List<GetAllSuperpoderesDto>>(SuperpoderErrors.TableEmpty);
        }

        return superpoders.Select(s => new GetAllSuperpoderesDto(s.Id, s.Poder, s.Descricao)).ToList();
    }
}
