using LocadoraFilmesApi.Service.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.CrossCutting.IoC
{
    [ExcludeFromCodeCoverage]
    public static class DataBaseConfiguration
    {
        public static void ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("LocadoraConnection"), serverVersion));
        }
    }
}
