using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraFilmesApi.Service.CrossCutting.IoC
{
    public static class MapperConfig
    {
        public static void ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToDtoMappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
