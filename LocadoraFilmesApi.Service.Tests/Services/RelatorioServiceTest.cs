using AutoMapper;
using FluentAssertions;
using LocadoraclientesApi.Service.Tests.Builders;
using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Services;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Tests.Builders;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LocadoraFilmesApi.Service.Tests.Services
{
    public class RelatorioServiceTest
    {
        private readonly ILogger<RelatorioService> _logger;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Mock<IFilmeRepository> _filmeRepository;

        public RelatorioServiceTest()
        {
            _logger = new Mock<ILogger<RelatorioService>>().Object;
            _mapper = new Mock<IMapper>();
            _clienteRepository = new Mock<IClienteRepository>();
            _filmeRepository = new Mock<IFilmeRepository>();
        }

        [Fact]
        public async Task Service_GetClienteAtrasado_ReturnsMemory()
        {

            _clienteRepository.Setup(f => f.GetAtrasados())
                .ReturnsAsync(new ClienteBuilder().BuilderList());

            var service = new RelatorioService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object,
                _filmeRepository.Object);

            var result = await service.ClientesEmAtraso();

            result.Should().NotBeNull();
            Assert.True(result != null);
        }

        [Fact]
        public async Task Service_GetClienteAtrasado_ReturnsError()
        {
            _clienteRepository.Setup(f => f.GetAtrasados())
                .ThrowsAsync(new Exception());

            var service = new RelatorioService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object,
                _filmeRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(() => service.ClientesEmAtraso());
        }

        [Fact]
        public async Task Service_GetFilmesNuncaAlugados_ReturnsMemory()
        {

            _filmeRepository.Setup(f => f.GetNuncaAlugados())
                .ReturnsAsync(new FilmeBuilder().BuilderList());

            var service = new RelatorioService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object,
                _filmeRepository.Object);

            var result = await service.FilmesNuncaAlugados();

            result.Should().NotBeNull();
            Assert.True(result != null);
        }

        [Fact]
        public async Task Service_GetFilmesNuncaAlugados_ReturnsError()
        {
            _filmeRepository.Setup(f => f.GetNuncaAlugados())
                .ThrowsAsync(new Exception());

            var service = new RelatorioService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object,
                _filmeRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(() => service.FilmesNuncaAlugados());
        }

        [Fact]
        public async Task Service_GetSegundoClienteMaisAlugou_ReturnsMemory()
        {

            _clienteRepository.Setup(f => f.GetSegundoClienteMaisAlugou())
                .ReturnsAsync(new ClienteBuilder().BuilderList());

            var service = new RelatorioService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object,
                _filmeRepository.Object);

            var result = await service.SegundoClienteMaisAlugou();

            result.Should().NotBeNull();
            Assert.True(result != null);
        }

        [Fact]
        public async Task Service_GetSegundoClienteMaisAlugou_ReturnsError()
        {
            _clienteRepository.Setup(f => f.GetSegundoClienteMaisAlugou())
                .ThrowsAsync(new Exception());

            var service = new RelatorioService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object,
                _filmeRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(() => service.SegundoClienteMaisAlugou());
        }

        [Fact]
        public async Task Service_GetTop3MenosAlugados_ReturnsMemory()
        {

            _filmeRepository.Setup(f => f.GetTop3MenosAlugados())
                .ReturnsAsync(new FilmeBuilder().BuilderList());

            var service = new RelatorioService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object,
                _filmeRepository.Object);

            var result = await service.Top3MenosAlugados();

            result.Should().NotBeNull();
            Assert.True(result != null);
        }

        [Fact]
        public async Task Service_GetTop3MenosAlugados_ReturnsError()
        {
            _filmeRepository.Setup(f => f.GetTop3MenosAlugados())
                .ThrowsAsync(new Exception());

            var service = new RelatorioService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object,
                _filmeRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(() => service.Top3MenosAlugados());
        }

        [Fact]
        public async Task Service_GetTop5MaisAlugados_ReturnsMemory()
        {

            _filmeRepository.Setup(f => f.GetTop5Alugados())
                .ReturnsAsync(new FilmeBuilder().BuilderList());

            var service = new RelatorioService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object,
                _filmeRepository.Object);

            var result = await service.Top5MaisAlugados();

            result.Should().NotBeNull();
            Assert.True(result != null);
        }

        [Fact]
        public async Task Service_GetTop5MaisAlugados_ReturnsError()
        {
            _filmeRepository.Setup(f => f.GetTop5Alugados())
                .ThrowsAsync(new Exception());

            var service = new RelatorioService(
                _logger,
                _mapper.Object,
                _clienteRepository.Object,
                _filmeRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(() => service.Top5MaisAlugados());
        }
    }
}
