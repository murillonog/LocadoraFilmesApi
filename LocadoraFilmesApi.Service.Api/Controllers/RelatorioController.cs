using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/relatorios")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(byte[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult<byte[]>> Get()
        {
            try
            {
                var response = await _relatorioService.ClientesEmAtraso();
                return Ok(response);
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }
    }
}
