using AutoMapper;
using ClosedXML.Excel;
using LocadoraFilmesApi.Service.Application.Exceptions;
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

        public async Task<XLWorkbook> ClientesEmAtraso()
        {
            try
            {
                var result = await _clienteRepository.GetAtrasados();

                return new XLWorkbook();
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao buscar o relatório de clientes em atraso.");
                _logger.LogError(exception, HanddleError<object>.Handle(null, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<XLWorkbook> FilmesNuncaAlugados()
        {
            try
            {
                var result = await _filmeRepository.GetNuncaAlugados();

                return new XLWorkbook();
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao buscar o relatório de filmes nunca alugados.");
                _logger.LogError(exception, HanddleError<object>.Handle(null, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public Task<XLWorkbook> SegundoClienteMaisAlugou()
        {
            throw new NotImplementedException();
        }

        public Task<XLWorkbook> Top3MenosAlugados()
        {
            throw new NotImplementedException();
        }

        public Task<XLWorkbook> Top5MaisAlugados()
        {
            throw new NotImplementedException();
        }
    }
}
