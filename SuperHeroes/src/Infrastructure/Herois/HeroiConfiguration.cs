using Domain.HeroisAggregated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Herois;

public class HeroiConfiguration : IEntityTypeConfiguration<Heroi>
{
    public void Configure(EntityTypeBuilder<Heroi> builder)
    {
        builder.HasKey(h => h.Id);

        builder
            .Property(h => h.Nome)
            .HasColumnType("nvarchar(120")
            .IsRequired();

        builder
            .Property(h => h.NomeHeroi)
            .HasColumnType("nvarchar(120)")
            .IsRequired();

        builder
            .Property(h => h.DataNascimento)
            .HasColumnType("datetime2(7)")
            .IsRequired(false);

        builder
            .Property(h => h.Altura)
            .HasColumnType("float")
            .IsRequired();

        builder
            .Property(h => h.Peso)
            .HasColumnType("float")
            .IsRequired();

        builder
            .HasMany(h => h.Superpoderes)
            .WithMany(s => s.Herois)
            .UsingEntity(j => j.ToTable("HeroisSuperpoderes"));
    }
}
