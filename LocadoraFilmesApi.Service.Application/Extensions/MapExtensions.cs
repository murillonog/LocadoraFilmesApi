using LocadoraFilmesApi.Service.Application.ViewModel;
using LocadoraFilmesApi.Service.Domain.Entities;
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
    }
}
