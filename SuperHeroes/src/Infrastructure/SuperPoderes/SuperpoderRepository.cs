using Domain.HeroisAggregated;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SuperPoderes;

public class SuperpoderRepository(ApplicationDbContext context)
    : ISuperpoderRepository
{
    public async Task<List<Superpoder>> GetAllSuperpoderes()
    {
        return await context.Superpoderes.ToListAsync();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}
