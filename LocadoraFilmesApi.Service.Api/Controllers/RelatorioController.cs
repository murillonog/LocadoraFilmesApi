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

        [HttpGet("clientes-em-atraso")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(byte[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<IActionResult> GetClientesAtraso()
        {
            try
            {
                var response = await _relatorioService.ClientesEmAtraso();                

                return File(response.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ClientesAtraso.xlsx");
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpGet("filmes-nunca-alugados")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(byte[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<IActionResult> GetNuncaAlugados()
        {
            try
            {
                var response = await _relatorioService.FilmesNuncaAlugados();

                return File(response.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "FilmesNuncaAlugados.xlsx");
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpGet("filmes-top5-alugados")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(byte[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<IActionResult> GetTop5Alugados()
        {
            try
            {
                var response = await _relatorioService.Top5MaisAlugados();

                return File(response.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Top5MaisAlugados.xlsx");
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpGet("filmes-top3-menos-alugados")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(byte[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<IActionResult> GetTop3MenosAlugados()
        {
            try
            {
                var response = await _relatorioService.Top3MenosAlugados();

                return File(response.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Top3MenosAlugados.xlsx");
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpGet("segundo-cliente-mais-alugou")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(byte[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<IActionResult> GetSegundClienteMaisAlugou()
        {
            try
            {
                var response = await _relatorioService.SegundoClienteMaisAlugou();

                return File(response.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SegundoClienteMaisAlugou.xlsx");
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }
    }
}
