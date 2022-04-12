using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Cliente : EntityBase
    {
        public virtual ICollection<Locacao> Locacao { get; set; }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
