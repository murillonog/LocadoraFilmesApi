using AutoMapper;
using FluentAssertions;
using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Services;
using LocadoraFilmesApi.Service.Application.ViewModel;
using LocadoraFilmesApi.Service.Domain.Entities;
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
    public class LocacaoServiceTest
    {
        private readonly ILogger<LocacaoService> _logger;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILocacaoRepository> _locacaoRepository;

        public LocacaoServiceTest()
        {
            _logger = new Mock<ILogger<LocacaoService>>().Object;
            _mapper = new Mock<IMapper>();
            _locacaoRepository = new Mock<ILocacaoRepository>();
        }

        [Fact]
        public async Task Service_AddLocacao_ReturnsId()
        {
            var locacao = new LocacaoBuilder().Builder();
            var locacaoCreate = new LocacaoBuilder().BuilderCreate();

            _locacaoRepository.Setup(f => f.Add(locacao))
                .ReturnsAsync(locacao);

            _mapper.Setup(f => f.Map<Locacao>(locacaoCreate))
                .Returns(() => locacao);

            var service = new LocacaoService(
                _logger,
                _mapper.Object,
                _locacaoRepository.Object);

            var result = await service.Add(locacaoCreate);

            result.Should().BePositive();
            Assert.True(result > 0);
        }

        [Fact]
        public async Task Service_AddLocacao_ReturnsError()
        {
            _locacaoRepository.Setup(f => f.Add(new LocacaoBuilder().Builder()))
                .ThrowsAsync(new Exception());

            var service = new LocacaoService(
                _logger,
                _mapper.Object,
                _locacaoRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(
                () => service.Add(It.IsAny<LocacaoCreate>()));
        }

        [Fact]
        public async Task Service_DeleteLocacao_Ok()
        {
            var locacao = new LocacaoBuilder().Builder();

            _locacaoRepository.Setup(f => f.Delete(It.IsAny<int>()));

            _locacaoRepository.Setup(f => f.GetById(It.IsAny<int>()))
                .ReturnsAsync(locacao);

            var service = new LocacaoService(
                _logger,
                _mapper.Object,
                _locacaoRepository.Object);

            await service.Delete(It.IsAny<int>());
            _locacaoRepository.Verify(c => c.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task Service_DeleteLocacao_ReturnsError()
        {
            var locacao = new LocacaoBuilder().Builder();

            _locacaoRepository.Setup(f => f.Delete(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            var service = new LocacaoService(
                _logger,
                _mapper.Object,
                _locacaoRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(
                () => service.Delete(It.IsAny<int>()));
        }

        [Fact]
        public async Task Service_GetLocacaos_ReturnsListDto()
        {
            var list = new LocacaoBuilder().BuilderList();
            var listDto = new LocacaoBuilder().BuilderListDto();

            _locacaoRepository.Setup(f => f.GetAllLocacoes())
                .ReturnsAsync(list);

            _mapper.Setup(f => f.Map<IEnumerable<LocacaoDto>>(list))
                .Returns(() => listDto);

            var service = new LocacaoService(
                _logger,
                _mapper.Object,
                _locacaoRepository.Object);

            var result = await service.Get();

            result.Should().NotBeNull();
            Assert.True(result.Any());
        }

        [Fact]
        public async Task Service_GetLocacaos_ReturnsError()
        {
            _locacaoRepository.Setup(f => f.GetAllLocacoes())
                .ThrowsAsync(new Exception());

            var service = new LocacaoService(
                _logger,
                _mapper.Object,
                _locacaoRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(() => service.Get());
        }

        [Fact]
        public async Task Service_GetLocacaoById_ReturnsListDto()
        {
            var locacao = new LocacaoBuilder().Builder();
            var locacaoDto = new LocacaoBuilder().BuilderDto();

            _locacaoRepository.Setup(f => f.GetById(It.IsAny<int>()))
                .ReturnsAsync(locacao);

            _mapper.Setup(f => f.Map<LocacaoDto>(locacao))
                .Returns(() => locacaoDto);

            var service = new LocacaoService(
                _logger,
                _mapper.Object,
                _locacaoRepository.Object);

            var result = await service.GetById(It.IsAny<int>());

            result.Should().NotBeNull();
            Assert.True(result != null);
        }

        [Fact]
        public async Task Service_GetLocacaoById_ReturnsError()
        {
            _locacaoRepository.Setup(f => f.GetById(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            var service = new LocacaoService(
                _logger,
                _mapper.Object,
                _locacaoRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(() => service.GetById(It.IsAny<int>()));
        }

        [Fact]
        public async Task Service_UpdateLocacao_ReturnsLocacao()
        {
            var locacao = new LocacaoBuilder().Builder();
            var locacaoDto = new LocacaoBuilder().BuilderDto();
            var locacaoUpdate = new LocacaoBuilder().BuilderUpdate();

            _locacaoRepository.Setup(f => f.Update(locacao))
                .ReturnsAsync(locacao);

            _locacaoRepository.Setup(f => f.GetById(It.IsAny<int>()))
                .ReturnsAsync(locacao);

            _mapper.Setup(f => f.Map<Locacao>(locacaoUpdate))
                .Returns(() => locacao);

            _mapper.Setup(f => f.Map<LocacaoDto>(locacao))
                .Returns(() => locacaoDto);

            var service = new LocacaoService(
                _logger,
                _mapper.Object,
                _locacaoRepository.Object);

            var result = await service.Update(It.IsAny<int>(), locacaoUpdate);

            result.Should().NotBeNull();
            Assert.True(result != null);
        }

        [Fact]
        public async Task Service_UpdateLocacao_NotFoundLocacao()
        {
            var locacao = new LocacaoBuilder().Builder();
            var locacaoDto = new LocacaoBuilder().BuilderDto();
            var locacaoUpdate = new LocacaoBuilder().BuilderUpdate();

            _locacaoRepository.Setup(f => f.Update(locacao))
                .ReturnsAsync(locacao);

            _locacaoRepository.Setup(f => f.GetById(It.IsAny<int>()));

            _mapper.Setup(f => f.Map<Locacao>(locacaoUpdate))
                .Returns(() => locacao);

            _mapper.Setup(f => f.Map<LocacaoDto>(locacao))
                .Returns(() => locacaoDto);

            var service = new LocacaoService(
                _logger,
                _mapper.Object,
                _locacaoRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(
                () => service.Update(It.IsAny<int>(), It.IsAny<LocacaoUpdate>()));
        }

        [Fact]
        public async Task Service_UpdateLocacao_ReturnsError()
        {
            _locacaoRepository.Setup(f => f.Update(new LocacaoBuilder().Builder()))
                .ThrowsAsync(new Exception());

            var service = new LocacaoService(
                _logger,
                _mapper.Object,
                _locacaoRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(
                () => service.Update(It.IsAny<int>(), It.IsAny<LocacaoUpdate>()));
        }
    }
}
