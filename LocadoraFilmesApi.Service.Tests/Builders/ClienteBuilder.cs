using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.ViewModel;
using LocadoraFilmesApi.Service.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LocadoraclientesApi.Service.Tests.Builders
{
    public class ClienteBuilder
    {
        private readonly Cliente _cliente;
        private readonly ClienteDto _clienteDto;
        private readonly ClienteCreate _clienteCreate;
        private readonly ClienteUpdate _clienteUpdate;
        private readonly List<Cliente> _listCliente;
        private readonly List<ClienteDto> _listClienteDto;

        public ClienteBuilder()
        {
            _cliente = new Cliente()
            {
                Id = 1,
                Nome = "Nome teste",
                Cpf = "12123141234",
                DataNascimento = new DateTime()
            };

            _clienteDto = new ClienteDto()
            {
                Nome = "Nome teste",
                Cpf = "12123141234",
                DataNascimento = new DateTime()
            };

            _clienteCreate = new ClienteCreate()
            {
                Nome = "Nome teste",
                Cpf = "12123141234",
                DataNascimento = new DateTime()
            };

            _clienteUpdate = new ClienteUpdate()
            {
                Nome = "Nome teste",
                Cpf = "12123141234",
                DataNascimento = new DateTime()
            };

            _listCliente = new List<Cliente>() { _cliente, _cliente };

            _listClienteDto = new List<ClienteDto>() { _clienteDto, _clienteDto };
        }

        public Cliente Builder() => _cliente;
        public ClienteDto BuilderDto() => _clienteDto;
        public ClienteCreate BuilderCreate() => _clienteCreate;
        public ClienteUpdate BuilderUpdate() => _clienteUpdate;
        public List<Cliente> BuilderList() => _listCliente;
        public List<ClienteDto> BuilderListDto() => _listClienteDto;
    }
}
