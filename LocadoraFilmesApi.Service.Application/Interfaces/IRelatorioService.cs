using ClosedXML.Excel;

namespace LocadoraFilmesApi.Service.Application.Interfaces
{
    public interface IRelatorioService
    {
        Task<MemoryStream> ClientesEmAtraso();
        Task<MemoryStream> FilmesNuncaAlugados();
        Task<MemoryStream> Top5MaisAlugados();
        Task<MemoryStream> Top3MenosAlugados();
        Task<MemoryStream> SegundoClienteMaisAlugou();
    }
}
