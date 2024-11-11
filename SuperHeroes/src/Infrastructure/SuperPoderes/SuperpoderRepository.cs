using Domain.HeroisAggregated;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SuperPoderes;

public class SuperpoderRepository(ApplicationDbContext context)
    : ISuperpoderRepository
{
    public async Task<List<Superpoder>> GetAllSuperpoderesAsync(CancellationToken cancellationToken)
    {
        return await context.Superpoderes.ToListAsync(cancellationToken);
    }

    public async Task<List<Superpoder>> GetSuperpoderesListFromIdListAsync(List<Int32> idList, CancellationToken cancellationToken)
    {
        return await context.Superpoderes
            .Where(x => idList.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}
