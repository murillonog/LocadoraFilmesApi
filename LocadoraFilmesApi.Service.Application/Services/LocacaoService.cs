using AutoMapper;
using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Extensions;
using LocadoraFilmesApi.Service.Application.Interfaces;
using LocadoraFilmesApi.Service.Application.ViewModel;
using LocadoraFilmesApi.Service.Domain.Entities;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Domain.Models;
using LocadoraFilmesApi.Service.Domain.Util;
using Microsoft.Extensions.Logging;

namespace LocadoraFilmesApi.Service.Application.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly ILogger<LocacaoService> _logger;
        private readonly IMapper _mapper;
        private readonly ILocacaoRepository _locacaoRepository;

        public LocacaoService(
            ILogger<LocacaoService> logger,
            IMapper mapper,
            ILocacaoRepository locacaoRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _locacaoRepository = locacaoRepository;
        }

        public async Task<int> Add(LocacaoCreate locacaoCreate)
        {
            try
            {
                var locacao = _mapper.Map<Locacao>(locacaoCreate);
                var entity = await _locacaoRepository.Add(locacao);
                return entity.Id;
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao inserir o locação no banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(locacaoCreate, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                if (await _locacaoRepository.GetById(id) == null)
                {
                    throw new KeyNotFoundException("Locação não existe!");
                }

                await _locacaoRepository.Delete(id);
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao deletar o locação no banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(id, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<IEnumerable<LocacaoDto>> Get()
        {
            try
            {
                var list = await _locacaoRepository.GetAllLocacoes();
                return _mapper.Map<IEnumerable<LocacaoDto>>(list);
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao buscar todas locações no banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(null, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<LocacaoDto> GetById(int id)
        {
            try
            {
                var locacao = await _locacaoRepository.GetById(id);
                return _mapper.Map<LocacaoDto>(locacao);
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao buscar a locação no banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(id, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<LocacaoDto> Update(int id, LocacaoUpdate locacaoUpdate)
        {
            try
            {
                var locacao = await _locacaoRepository.GetById(id);
                if (locacao == null)
                {
                    throw new KeyNotFoundException("Cliente não existe!");
                }

                locacao.ToUpdate(locacaoUpdate);

                var entity = await _locacaoRepository.Update(locacao);
                return _mapper.Map<LocacaoDto>(entity);
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao atualizar a locação no banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(locacaoUpdate, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }
    }
}
