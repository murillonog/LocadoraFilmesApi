using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Interfaces;
using LocadoraFilmesApi.Service.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/locacao")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoService _locacaoService;

        public LocacaoController(ILocacaoService locacaoService)
        {
            _locacaoService = locacaoService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult> Add([FromBody] LocacaoCreate locacaoCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var response = await _locacaoService.Add(locacaoCreate);
                return Created("Created", response);
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocacaoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult> Put(int id, [FromBody] LocacaoUpdate locacaoUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var response = await _locacaoService.Update(id, locacaoUpdate);
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
                await _locacaoService.Delete(id);
                return NoContent();
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LocacaoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult<IEnumerable<LocacaoDto>>> Get()
        {
            try
            {
                var response = await _locacaoService.Get();
                return Ok(response);
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocacaoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult<LocacaoDto>> GetById(int id)
        {
            try
            {
                var response = await _locacaoService.GetById(id);
                return Ok(response);
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }
    }
}
