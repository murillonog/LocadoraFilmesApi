using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Application.Dtos
{
    [ExcludeFromCodeCoverage]
    public class ClienteDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
