using LocadoraFilmesApi.Service.Application.Interfaces;
using LocadoraFilmesApi.Service.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraFilmesApi.Service.CrossCutting.IoC
{
    public static class ServiceConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<ILocacaoService, LocacaoService>();
            services.AddScoped<IRelatorioService, RelatorioService>();
        }
    }
}
