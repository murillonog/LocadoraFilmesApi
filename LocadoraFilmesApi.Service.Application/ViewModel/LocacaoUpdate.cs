using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Application.ViewModel
{
    [ExcludeFromCodeCoverage]
    public class LocacaoUpdate
    {
        [Required]
        public int Id_Cliente { get; set; }
        [Required]
        public int Id_Filme { get; set; }
        [Required]
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
