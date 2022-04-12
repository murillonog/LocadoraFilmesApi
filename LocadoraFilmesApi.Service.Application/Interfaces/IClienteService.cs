using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.ViewModel;

namespace LocadoraFilmesApi.Service.Application.Interfaces
{
    public interface IClienteService
    {
        Task<int> Add(ClienteCreate clienteCreate);
        Task<ClienteDto> Update(int id, ClienteUpdate clienteUpdate);
        Task Delete(int id);
        Task<IEnumerable<ClienteDto>> Get();
        Task<ClienteDto> GetById(int id);
    }
}
