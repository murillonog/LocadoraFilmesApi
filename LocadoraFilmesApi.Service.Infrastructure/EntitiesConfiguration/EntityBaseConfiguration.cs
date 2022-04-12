using LocadoraFilmesApi.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Infrastructure.EntitiesConfiguration
{
    [ExcludeFromCodeCoverage]
    public static class EntityBaseConfiguration<T> where T : EntityBase
    {
        public static void Configure(EntityTypeBuilder<T> builder)
        {
            //Attributes
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
