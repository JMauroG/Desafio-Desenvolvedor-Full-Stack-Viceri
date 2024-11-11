using Domain.HeroisAggregated;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Herois;

public class HeroisRepository(ApplicationDbContext context) : IHeroisRepository
{
    public async Task<List<Heroi>> GetAllHeroisAsync(CancellationToken cancellationToken)
    {
        return await context.Herois.ToListAsync(cancellationToken);
    }

    public async Task<List<Heroi>> GetAllHeroisReadOnlyAsync(CancellationToken cancellationToken)
    {
        return await context.Herois
            .AsNoTrackingWithIdentityResolution()
            .Include(h => h.Superpoderes)
            .ToListAsync(cancellationToken);
    }

    public async Task<Heroi> GetHeroiByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Herois.Include(h => h.Superpoderes)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Heroi> GetHeroiByIdReadOnlyAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Herois
            .AsNoTrackingWithIdentityResolution()
            .Include(h => h.Superpoderes)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Boolean> CheckIfHeroiNomeExistsAsync(string name, CancellationToken cancellationToken)
    {
        return await context.Herois.AsNoTrackingWithIdentityResolution()
            .AnyAsync(h => h.NomeHeroi.ToUpper() == name.ToUpper(), cancellationToken);
    }

    public async Task<Boolean> CheckIfHeroiNomeExistsWithIdAsync(string name, int id,
        CancellationToken cancellationToken)
    {
        return await context.Herois.AsNoTrackingWithIdentityResolution()
            .AnyAsync(h => h.NomeHeroi.ToUpper() == name.ToUpper() && h.Id != id, cancellationToken);
    }

    public void Update(Heroi heroi)
    {
        context.Herois.Update(heroi);
    }

    public async Task AddAsync(Heroi heroi, CancellationToken cancellationToken)
    {
        await context.Herois.AddAsync(heroi, cancellationToken);
    }

    public void Delete(Heroi heroi)
    {
        context.Remove(heroi);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}
