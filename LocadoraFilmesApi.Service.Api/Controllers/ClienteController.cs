using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult> Add([FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var response = await _clienteService.Add(clienteDto);
                return Created("Created", response);
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var response = await _clienteService.Update(id, clienteDto);
                return Accepted(response);
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _clienteService.Delete(id);
                return NoContent();
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClienteDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
        {
            try
            {
                var response = await _clienteService.Get();
                return Ok(response);
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult<ClienteDto>> GetById(int id)
        {
            try
            {
                var response = await _clienteService.GetById(id);
                return Ok(response);
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }
    }
}
