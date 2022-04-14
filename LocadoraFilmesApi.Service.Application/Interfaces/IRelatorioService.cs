using ClosedXML.Excel;

namespace LocadoraFilmesApi.Service.Application.Interfaces
{
    public interface IRelatorioService
    {
        Task<XLWorkbook> ClientesEmAtraso();
        Task<XLWorkbook> FilmesNuncaAlugados();
        Task<XLWorkbook> Top5MaisAlugados();
        Task<XLWorkbook> Top3MenosAlugados();
        Task<XLWorkbook> SegundoClienteMaisAlugou();
    }
}
