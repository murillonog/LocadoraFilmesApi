namespace LocadoraFilmesApi.Service.Application.Dtos
{
    public class FilmeDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public int Lancamento { get; set; }
    }
}
