using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Domain.Entities;

namespace LocadoraFilmesApi.Service.Application.Extensions
{
    public static class MapExtensions
    {
        public static Cliente ToUpdate(this Cliente cliente, ClienteDto clienteDto)
        {
            cliente.Cpf = clienteDto.Cpf;
            cliente.Nome = clienteDto.Nome;
            cliente.DataNascimento = clienteDto.DataNascimento;
            return cliente;
        }
    }
}
