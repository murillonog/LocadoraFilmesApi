using LocadoraFilmesApi.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Infrastructure.EntitiesConfiguration
{
    [ExcludeFromCodeCoverage]
    public class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            EntityBaseConfiguration<Locacao>.Configure(builder);

            //Relationships
            builder.HasOne(x => x.Cliente)
                    .WithMany(x => x.Locacao)
                    .HasForeignKey(x => x.Id_Cliente)
                    .IsRequired();

            builder.HasOne(x => x.Filme)
                    .WithMany(x => x.Locacao)
                    .HasForeignKey(x => x.Id_Filme)
                    .IsRequired();

            builder.Property(c => c.DataLocacao)
                .HasColumnType("DATETIME");

            builder.Property(c => c.DataDevolucao)
                .HasColumnType("DATETIME");
        }
    }
}
