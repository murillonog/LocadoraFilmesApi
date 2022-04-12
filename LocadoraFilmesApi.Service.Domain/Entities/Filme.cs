using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Filme : EntityBase
    {
        public virtual ICollection<Locacao> Locacao { get; set; }

        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public int Lancamento { get; set; }
    }
}
