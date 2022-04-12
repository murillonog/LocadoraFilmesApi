using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Application.Dtos
{
    [ExcludeFromCodeCoverage]
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
