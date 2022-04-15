using AutoMapper;
using FluentAssertions;
using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Services;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Tests.Builders;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LocadoraFilmesApi.Service.Tests.Services
{
    public class FilmeServiceTest
    {
        private readonly ILogger<FilmeService> _logger;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IFilmeRepository> _filmeRepository;

        public FilmeServiceTest()
        {
            _logger = new Mock<ILogger<FilmeService>>().Object;
            _mapper = new Mock<IMapper>();
            _filmeRepository = new Mock<IFilmeRepository>();
        }

        [Fact]
        public async Task Service_GetFilmes_ReturnsListDto()
        {
            var list = new FilmeBuilder().BuilderList();
            var listDto = new FilmeBuilder().BuilderListDto();

            _filmeRepository.Setup(f => f.GetAll())
                .ReturnsAsync(list);

            _mapper.Setup(f => f.Map<IEnumerable<FilmeDto>>(list))
                .Returns(() => listDto);

            var service = new FilmeService(
                _logger,
                _mapper.Object,
                _filmeRepository.Object);

            var result = await service.Get();

            result.Should().NotBeNull();
            Assert.True(result.Any());
        }

        [Fact]
        public async Task Service_GetFilmes_ReturnsError()
        {
            _filmeRepository.Setup(f => f.GetAll())
                .ThrowsAsync(new Exception());

            var service = new FilmeService(
                _logger,
                _mapper.Object,
                _filmeRepository.Object);

            await Assert.ThrowsAsync<ServiceException>(() => service.Get());
        }
    }
}
