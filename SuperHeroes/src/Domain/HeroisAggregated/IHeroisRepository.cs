using SharedKernel;

namespace Domain.HeroisAggregated;

public interface IHeroisRepository: IUnitOfWork
{
    Task<List<Heroi>> GetAllHeroisAsync(CancellationToken cancellationToken);
    Task<List<Heroi>> GetAllHeroisReadOnlyAsync(CancellationToken cancellationToken);
    Task<Heroi> GetHeroiByIdAsync(int id, CancellationToken cancellationToken);
    Task<Heroi> GetHeroiByIdReadOnlyAsync(int id, CancellationToken cancellationToken);
    Task<bool> CheckIfHeroiNomeExistsAsync(string name, CancellationToken cancellationToken);
    Task<bool> CheckIfHeroiNomeExistsWithIdAsync(string name, int id, CancellationToken cancellationToken);
    void Update(Heroi heroi);
    Task AddAsync(Heroi heroi, CancellationToken cancellationToken);
    void Delete(Heroi heroi);
}
