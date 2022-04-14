using AutoMapper;
using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Extensions;
using LocadoraFilmesApi.Service.Application.Interfaces;
using LocadoraFilmesApi.Service.Domain.Entities;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Domain.Models;
using LocadoraFilmesApi.Service.Domain.Util;
using Microsoft.AspNetCore.Http;
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

        public async Task<IEnumerable<FilmeDto>> Add(IFormFile file)
        {
            try
            {
                var dt = file.ConvertCSVtoDataTable();
                var list = dt.ConvertDataTabletoFilmeDto();
                var listEntity = _mapper.Map<IEnumerable<Filme>>(list);

                foreach (var filme in listEntity)
                {
                    if (await _filmeRepository.GetById(filme.Id) == null)
                    {
                        await _filmeRepository.Add(filme);
                    }
                }

                return _mapper.Map<IEnumerable<FilmeDto>>(list);
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao importar lista de filmes no banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(file, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<IEnumerable<FilmeDto>> Get()
        {
            try
            {
                var list = await _filmeRepository.GetAll();
                return _mapper.Map<IEnumerable<FilmeDto>>(list);
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.02", "Erro ao buscar lista de filmes no banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(null, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }
    }
}
