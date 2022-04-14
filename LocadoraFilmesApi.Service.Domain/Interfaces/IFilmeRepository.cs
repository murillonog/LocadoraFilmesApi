using LocadoraFilmesApi.Service.Domain.Entities;

namespace LocadoraFilmesApi.Service.Domain.Interfaces
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        Task<IEnumerable<Filme>> GetNuncaAlugados();
        Task<IEnumerable<Filme>> GetTop5Alugados();
        Task<IEnumerable<Filme>> GetTop3MenosAlugados();
    }
}
