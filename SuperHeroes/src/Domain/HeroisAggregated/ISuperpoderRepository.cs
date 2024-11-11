using SharedKernel;

namespace Domain.HeroisAggregated;

public interface ISuperpoderRepository: IUnitOfWork
{
    Task<List<Superpoder>> GetAllSuperpoderesAsync(CancellationToken cancellationToken);
    Task<List<Superpoder>> GetSuperpoderesListFromIdListAsync(List<int> idList, CancellationToken cancellationToken);
}
