using LocadoraFilmesApi.Service.Domain.Entities;

namespace LocadoraFilmesApi.Service.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetAtrasados();
        Task<IEnumerable<Cliente>> GetSegundoClienteMaisAlugou();
    }
}
