using Domain.HeroisAggregated;
using Infrastructure.Herois;
using Infrastructure.SuperPoderes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Heroi> Herois { get; set; }
    public DbSet<Superpoder> Superpoderes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new HeroiConfiguration());
        modelBuilder.ApplyConfiguration(new SuperpoderConfiguration());

        modelBuilder.HasDefaultSchema(Schemas.Default);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}
