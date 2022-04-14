using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Locacao : EntityBase
    {
        public virtual Cliente Cliente { get; set; }
        public int Id_Cliente { get; set; }
        public virtual Filme Filme { get; set; }
        public int Id_Filme { get; set; }

        public DateTime DataLocacao { get; set; }
        public DateTime? DataDevolucao { get; set; }

        [NotMapped]
        public string NomeCliente { get; set; }
        [NotMapped]
        public string TituloFilme { get; set; }
    }
}
