using AutoMapper;
using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Extensions;
using LocadoraFilmesApi.Service.Application.Interfaces;
using LocadoraFilmesApi.Service.Domain.Entities;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Domain.Models;
using LocadoraFilmesApi.Service.Domain.Util;
using Microsoft.Extensions.Logging;

namespace LocadoraFilmesApi.Service.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ILogger<ClienteService> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(
            ILogger<ClienteService> logger, 
            IMapper mapper, 
            IClienteRepository clienteRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<int> Add(ClienteDto clienteDto)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDto);
                var entity = await _clienteRepository.Add(cliente);
                return entity.Id;
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.01", "Erro ao inserir o cliente no banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(clienteDto, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                if (await _clienteRepository.GetById(id) == null)
                {
                    throw new KeyNotFoundException("Cliente não existe!");
                }

                await _clienteRepository.Delete(id);
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.02", "Erro ao deletar o cliente do banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(id, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<IEnumerable<ClienteDto>> Get()
        {
            try
            {
                var list = await _clienteRepository.GetAll();
                return _mapper.Map<IEnumerable<ClienteDto>>(list);
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.03", "Erro ao buscar a lista de clientes do banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(null, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<ClienteDto> GetById(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetById(id);
                return _mapper.Map<ClienteDto>(cliente);
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.04", "Erro ao buscar o cliente por id do banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(id, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }

        public async Task<ClienteDto> Update(int id, ClienteDto clienteDto)
        {
            try
            {
                var cliente = await _clienteRepository.GetById(id);
                if (cliente == null)
                {
                    throw new KeyNotFoundException("Cliente não existe!");
                }

                cliente.ToUpdate(clienteDto);

                var entity = await _clienteRepository.Update(cliente);
                return _mapper.Map<ClienteDto>(entity);
            }
            catch (Exception exception)
            {
                var errMsg = new ErrorMessage("01.05", "Erro ao atualizar o cliente no banco de dados");
                _logger.LogError(exception, HanddleError<object>.Handle(clienteDto, exception, errMsg));
                throw new ServiceException(errMsg.Code, errMsg.Message, exception);
            }
        }
    }
}
