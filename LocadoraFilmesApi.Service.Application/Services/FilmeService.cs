using AutoMapper;
using LocadoraFilmesApi.Service.Application.Interfaces;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace LocadoraFilmesApi.Service.Application.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly ILogger<FilmeService> _logger;
        private readonly IMapper _mapper;
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(
            ILogger<FilmeService> logger, 
            IMapper mapper, 
            IFilmeRepository filmeRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _filmeRepository = filmeRepository;
        }        
    }
}
