using AutoMapper;
using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.CrossCutting.IoC
{
    [ExcludeFromCodeCoverage]
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
