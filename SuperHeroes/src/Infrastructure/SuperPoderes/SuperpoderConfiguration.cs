using Domain.HeroisAggregated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.SuperPoderes;

public class SuperpoderConfiguration : IEntityTypeConfiguration<Superpoder>
{
    public void Configure(EntityTypeBuilder<Superpoder> builder)
    {
        builder
            .HasKey(s => s.Id);
        
        builder
            .Property(s => s.Poder)
            .HasColumnName("Superpoder")
            .HasColumnType("nvarchar(50)")
            .IsRequired();

        builder
            .Property(s => s.Descricao)
            .HasColumnType("nvarchar(250)")
            .IsRequired(false);
    }
}
