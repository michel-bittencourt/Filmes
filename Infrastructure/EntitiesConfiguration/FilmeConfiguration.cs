using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration;

public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
{
    public void Configure(EntityTypeBuilder<Filme> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Titulo)
               .IsRequired();
        builder.Property(f => f.Genero)
               .IsRequired();
        builder.Property(f => f.Duracao)
               .IsRequired();
    }
}
