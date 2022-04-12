using AutoMapper;
using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.ViewModel;
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
            CreateMap<Cliente, ClienteCreate>().ReverseMap();
            CreateMap<Cliente, ClienteUpdate>().ReverseMap();
            CreateMap<Filme, FilmeDto>().ReverseMap();
            CreateMap<Locacao, LocacaoDto>().ReverseMap();
            CreateMap<Locacao, LocacaoCreate>().ReverseMap();
            CreateMap<Locacao, LocacaoUpdate>().ReverseMap();
        }
    }
}
