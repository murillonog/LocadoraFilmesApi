using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.ViewModel;

namespace LocadoraFilmesApi.Service.Application.Interfaces
{
    public interface ILocacaoService
    {
        Task<int> Add(LocacaoCreate locacaoCreate);
        Task<LocacaoDto> Update(int id, LocacaoUpdate locacaoUpdate);
        Task Delete(int id);
        Task<IEnumerable<LocacaoDto>> Get();
        Task<LocacaoDto> GetById(int id);
    }
}
