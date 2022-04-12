using LocadoraFilmesApi.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Infrastructure.EntitiesConfiguration
{
    [ExcludeFromCodeCoverage]
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            EntityBaseConfiguration<Filme>.Configure(builder);

            builder.Property(c => c.Titulo)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.ClassificacaoIndicativa)
                .HasColumnType("INT");

            builder.Property(c => c.Lancamento)
                .HasColumnType("TINYINT");
        }
    }
}
