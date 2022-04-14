using LocadoraFilmesApi.Service.Application.Dtos;
using Microsoft.AspNetCore.Http;

namespace LocadoraFilmesApi.Service.Application.Interfaces
{
    public interface IFilmeService
    {
        Task<IEnumerable<FilmeDto>> Add(IFormFile file);
        Task<IEnumerable<FilmeDto>> Get();
    }
}
