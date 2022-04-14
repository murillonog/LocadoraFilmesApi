using LocadoraFilmesApi.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Infrastructure.EntitiesConfiguration
{
    [ExcludeFromCodeCoverage]
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnType("VARCHAR")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.DataNascimento)
                .HasColumnType("DATETIME");
        }
    }
}
