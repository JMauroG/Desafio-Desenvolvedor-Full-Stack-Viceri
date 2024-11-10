using SharedKernel;

namespace Domain.HeroisAggregated;

public interface ISuperpoderRepository: IUnitOfWork
{
    Task<List<Superpoder>> GetAllSuperpoderes();
}
