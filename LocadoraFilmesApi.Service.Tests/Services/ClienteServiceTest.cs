using AutoMapper;
using FluentAssertions;
using LocadoraclientesApi.Service.Tests.Builders;
using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Services;
using LocadoraFilmesApi.Service.Application.ViewModel;
using LocadoraFilmesApi.Service.Domain.Entities;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LocadoraFilmesApi.Service.Tests.Services
{
    public class ClienteServiceTest
    {
        private readonly ILogger<ClienteService> _logger;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IClienteRepository> _clienteRepository;

        public ClienteServiceTest()
        {
            _logger = new Mock<ILogger<ClienteService>>().Object;
            _mapper = new Mock<IMapper>();
            _clienteRepository = new Mock<IClienteRepository>();
        }

        [Fact]
        public async Task Service_AddCliente_ReturnsId()
        {
            var cliente = new ClienteBuilder().Builder();
            var clienteCreate = new ClienteBuilder().BuilderCreate();

            _clienteRepository.Setup(f => f.Add(cliente))
                .ReturnsAsync(cliente);

            _mapper.Setup(f => f.Map<Cliente>(clienteCreate))
                .Returns(() => cliente);

            var service = new ClienteService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object);

            var result = await service.Add(clienteCreate);

            result.Should().BePositive();
            Assert.True(result > 0);
        }

        [Fact]
        public async Task Service_AddCliente_ReturnsError()
        {
            _clienteRepository.Setup(f => f.Add(new ClienteBuilder().Builder()))
                .ThrowsAsync(new Exception());

            var service = new ClienteService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(
                () => service.Add(It.IsAny<ClienteCreate>()));
        }

        [Fact]
        public async Task Service_DeleteCliente_Ok()
        {
            var cliente = new ClienteBuilder().Builder();

            _clienteRepository.Setup(f => f.Delete(It.IsAny<int>()));

            _clienteRepository.Setup(f => f.GetById(It.IsAny<int>()))
                .ReturnsAsync(cliente);

            var service = new ClienteService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object);

            await service.Delete(It.IsAny<int>());
            _clienteRepository.Verify(c => c.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task Service_DeleteCliente_ReturnsError()
        {
            var cliente = new ClienteBuilder().Builder();

            _clienteRepository.Setup(f => f.Delete(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            var service = new ClienteService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(
                () => service.Delete(It.IsAny<int>()));
        }

        [Fact]
        public async Task Service_GetClientes_ReturnsListDto()
        {
            var list = new ClienteBuilder().BuilderList();
            var listDto = new ClienteBuilder().BuilderListDto();

            _clienteRepository.Setup(f => f.GetAll())
                .ReturnsAsync(list);

            _mapper.Setup(f => f.Map<IEnumerable<ClienteDto>>(list))
                .Returns(() => listDto);

            var service = new ClienteService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object);

            var result = await service.Get();

            result.Should().NotBeNull();
            Assert.True(result.Any());
        }

        [Fact]
        public async Task Service_GetClientes_ReturnsError()
        {
            _clienteRepository.Setup(f => f.GetAll())
                .ThrowsAsync(new Exception());

            var service = new ClienteService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(() => service.Get());
        }

        [Fact]
        public async Task Service_GetClienteById_ReturnsListDto()
        {
            var client = new ClienteBuilder().Builder();
            var clientDto = new ClienteBuilder().BuilderDto();

            _clienteRepository.Setup(f => f.GetById(It.IsAny<int>()))
                .ReturnsAsync(client);

            _mapper.Setup(f => f.Map<ClienteDto>(client))
                .Returns(() => clientDto);

            var service = new ClienteService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object);

            var result = await service.GetById(It.IsAny<int>());

            result.Should().NotBeNull();
            Assert.True(result != null);
        }

        [Fact]
        public async Task Service_GetClienteById_ReturnsError()
        {
            _clienteRepository.Setup(f => f.GetById(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            var service = new ClienteService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(() => service.GetById(It.IsAny<int>()));
        }

        [Fact]
        public async Task Service_UpdateCliente_ReturnsCliente()
        {
            var cliente = new ClienteBuilder().Builder();
            var clienteDto = new ClienteBuilder().BuilderDto();
            var clienteUpdate = new ClienteBuilder().BuilderUpdate();

            _clienteRepository.Setup(f => f.Update(cliente))
                .ReturnsAsync(cliente);

            _clienteRepository.Setup(f => f.GetById(It.IsAny<int>()))
                .ReturnsAsync(cliente);

            _mapper.Setup(f => f.Map<Cliente>(clienteUpdate))
                .Returns(() => cliente);

            _mapper.Setup(f => f.Map<ClienteDto>(cliente))
                .Returns(() => clienteDto);

            var service = new ClienteService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object);

            var result = await service.Update(It.IsAny<int>(),clienteUpdate);

            result.Should().NotBeNull();
            Assert.True(result != null);
        }

        [Fact]
        public async Task Service_UpdateCliente_NotFoundCliente()
        {
            var cliente = new ClienteBuilder().Builder();
            var clienteDto = new ClienteBuilder().BuilderDto();
            var clienteUpdate = new ClienteBuilder().BuilderUpdate();

            _clienteRepository.Setup(f => f.Update(cliente))
                .ReturnsAsync(cliente);

            _clienteRepository.Setup(f => f.GetById(It.IsAny<int>()));

            _mapper.Setup(f => f.Map<Cliente>(clienteUpdate))
                .Returns(() => cliente);

            _mapper.Setup(f => f.Map<ClienteDto>(cliente))
                .Returns(() => clienteDto);

            var service = new ClienteService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(
                () => service.Update(It.IsAny<int>(), It.IsAny<ClienteUpdate>()));
        }

        [Fact]
        public async Task Service_UpdateCliente_ReturnsError()
        {
            _clienteRepository.Setup(f => f.Update(new ClienteBuilder().Builder()))
                .ThrowsAsync(new Exception());

            var service = new ClienteService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(
                () => service.Update(It.IsAny<int>(), It.IsAny<ClienteUpdate>()));
        }
    }
}
