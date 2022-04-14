using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Application.ViewModel
{
    [ExcludeFromCodeCoverage]
    public class ClienteCreate
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
