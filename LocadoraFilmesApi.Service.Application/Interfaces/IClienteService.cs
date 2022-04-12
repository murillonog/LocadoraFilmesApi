using LocadoraFilmesApi.Service.Application.Dtos;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Application.Interfaces
{
    public interface IClienteService
    {
        Task<int> Add(ClienteDto clienteDto);
        Task<ClienteDto> Update(int id, ClienteDto clienteDto);
        Task Delete(int id);
        Task<IEnumerable<ClienteDto>> Get();
        Task<ClienteDto> GetById(int id);
    }
}
