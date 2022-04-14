using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraFilmesApi.Service.CrossCutting.IoC
{
    public static class RepositoryConfig
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<ILocacaoRepository, LocacaoRepository>();
        }
    }
}
