using ClosedXML.Excel;
using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.ViewModel;
using LocadoraFilmesApi.Service.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Application.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class MapExtensions
    {
        public static Cliente ToUpdate(this Cliente cliente, ClienteUpdate clienteUpdate)
        {
            cliente.Cpf = clienteUpdate.Cpf;
            cliente.Nome = clienteUpdate.Nome;
            cliente.DataNascimento = clienteUpdate.DataNascimento;
            return cliente;
        }

        public static Locacao ToUpdate(this Locacao locacao, LocacaoUpdate locacaoUpdate)
        {
            locacao.Id_Cliente = locacaoUpdate.Id_Cliente;
            locacao.Id_Filme = locacaoUpdate.Id_Filme;
            locacao.DataLocacao = locacaoUpdate.DataLocacao;
            locacao.DataDevolucao = locacaoUpdate.DataDevolucao;
            return locacao;
        }

        public static DataTable ConvertCSVtoDataTable(this IFormFile file)
        {
            DataTable dt = new DataTable();
            using (var stream = file.OpenReadStream())
            using (StreamReader sr = new StreamReader(stream))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }           

            return dt;
        }

        public static IEnumerable<FilmeDto> ConvertDataTabletoFilmeDto(this DataTable dt)
        {
            List<FilmeDto> listaFilmes = new List<FilmeDto>();
            foreach (DataRow row in dt.Rows)
            {
                if (row.ItemArray != null)
                {
                    var list = row.ItemArray[0].ToString().Split(';');

                    listaFilmes.Add(new FilmeDto
                    {
                        Id = Convert.ToInt32(list[0]),
                        Titulo = list[1],
                        ClassificacaoIndicativa = Convert.ToInt32(list[2]),
                        Lancamento = Convert.ToInt32(list[3])
                    });
                }
            }
            return listaFilmes;
        }

        public static MemoryStream ToMemoryStream(this IEnumerable<ClienteDto> listaCliente)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Clientes em Atraso");
            var currentRow = 1;

            worksheet.Cell(currentRow, 1).Value = "Id";
            worksheet.Cell(currentRow, 2).Value = "Nome";
            worksheet.Cell(currentRow, 3).Value = "Cpf";
            worksheet.Cell(currentRow, 4).Value = "Data Nascimento";

            foreach (var cliente in listaCliente)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = cliente.Id;
                worksheet.Cell(currentRow, 2).Value = cliente.Nome;
                worksheet.Cell(currentRow, 3).Value = cliente.Cpf;
                worksheet.Cell(currentRow, 4).Value = cliente.DataNascimento.ToString("dd/MM/yyyy");
            }

            using var memory = new MemoryStream();
            workbook.SaveAs(memory);

            return memory;
        }

        public static MemoryStream ToMemoryStream(this IEnumerable<FilmeDto> listaFilmes)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Clientes em Atraso");
            var currentRow = 1;

            worksheet.Cell(currentRow, 1).Value = "Id";
            worksheet.Cell(currentRow, 2).Value = "Titulo";
            worksheet.Cell(currentRow, 3).Value = "Classificação";
            worksheet.Cell(currentRow, 4).Value = "Lançamento";

            foreach (var filme in listaFilmes)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = filme.Id;
                worksheet.Cell(currentRow, 2).Value = filme.Titulo;
                worksheet.Cell(currentRow, 3).Value = filme.ClassificacaoIndicativa;
                worksheet.Cell(currentRow, 4).Value = filme.Lancamento;
            }

            using var memory = new MemoryStream();
            workbook.SaveAs(memory);

            return memory;
        }
    }
}
