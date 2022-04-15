using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Domain.Entities;
using System.Collections.Generic;

namespace LocadoraFilmesApi.Service.Tests.Builders
{
    public class FilmeBuilder
    {
        private readonly Filme _filme;
        private readonly FilmeDto _filmeDto;
        private readonly List<Filme> _listFilme;
        private readonly List<FilmeDto> _listFilmeDto;

        public FilmeBuilder()
        {
            _filme = new Filme()
            {
                Titulo = "Titulo teste",
                ClassificacaoIndicativa = 12,
                Lancamento = 1
            };

            _filmeDto = new FilmeDto()
            {
                Titulo = "Titulo teste",
                ClassificacaoIndicativa = 12,
                Lancamento = 1
            };

            _listFilme = new List<Filme>() { _filme, _filme };

            _listFilmeDto = new List<FilmeDto>() { _filmeDto, _filmeDto };
        }

        public Filme Builder() => _filme;
        public FilmeDto BuilderDto() => _filmeDto;
        public List<Filme> BuilderList() => _listFilme;
        public List<FilmeDto> BuilderListDto() => _listFilmeDto;
    }
}
