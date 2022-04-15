using AutoMapper;
using ClosedXML.Excel;
using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Extensions;
using LocadoraFilmesApi.Service.Application.Interfaces;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Domain.Models;
using LocadoraFilmesApi.Service.Domain.Util;
using Microsoft.Extensions.Logging;

namespace LocadoraFilmesApi.Service.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly ILogger<RelatorioService> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFilmeRepository _filmeRepository;

        public RelatorioService(
            ILogger<RelatorioService> logger,
            IMapper mapper,
            IClienteRepository clienteRepository,
            IFilmeRepository filmeRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _filmeRepository = filmeRepository;
        }

        public async Task<MemoryStream> ClientesEmAtraso()
        {
            try
            {
                var list = await _clienteRepository.GetAtrasados();
                var result = _mapper.Map<IEnumerable<ClienteDto>>(list);

                return result.ToMemoryStream();
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao buscar o relatório de clientes em atraso.");
                _logger.LogError(exception, HanddleError<object>.Handle(null, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<MemoryStream> FilmesNuncaAlugados()
        {
            try
            {
                var list = await _filmeRepository.GetNuncaAlugados();
                var result = _mapper.Map<IEnumerable<FilmeDto>>(list);

                return result.ToMemoryStream();
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao buscar o relatório de filmes nunca alugados.");
                _logger.LogError(exception, HanddleError<object>.Handle(null, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<MemoryStream> SegundoClienteMaisAlugou()
        {
            try
            {
                var list = await _clienteRepository.GetSegundoClienteMaisAlugou();
                var result = _mapper.Map<IEnumerable<ClienteDto>>(list);

                return result.ToMemoryStream();
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao buscar o relatório dos 5 filmes mais alugados.");
                _logger.LogError(exception, HanddleError<object>.Handle(null, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<MemoryStream> Top3MenosAlugados()
        {
            try
            {
                var list = await _filmeRepository.GetTop3MenosAlugados();
                var result = _mapper.Map<IEnumerable<FilmeDto>>(list);

                return result.ToMemoryStream();
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao buscar o relatório dos 5 filmes mais alugados.");
                _logger.LogError(exception, HanddleError<object>.Handle(null, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<MemoryStream> Top5MaisAlugados()
        {
            try
            {
                var list = await _filmeRepository.GetTop5Alugados();
                var result = _mapper.Map<IEnumerable<FilmeDto>>(list);

                return result.ToMemoryStream();
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao buscar o relatório dos 3 filmes menos alugados.");
                _logger.LogError(exception, HanddleError<object>.Handle(null, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }
    }
}
