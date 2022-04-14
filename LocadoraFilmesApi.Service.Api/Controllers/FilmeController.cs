using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.Exceptions;
using LocadoraFilmesApi.Service.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/filme")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost("import")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult> Add(IFormFile file)
        {
            try
            {
                var response = await _filmeService.Add(file);
                return Created("Created", response);
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<FilmeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<string>))]
        public async Task<ActionResult<IEnumerable<FilmeDto>>> Get()
        {
            try
            {
                var response = await _filmeService.Get();
                return Ok(response);
            }
            catch (ServiceException exception)
            {
                return Problem(exception.Details, null, 500, exception.DisplayMessage, exception.Error);
            }
        }
    }
}
