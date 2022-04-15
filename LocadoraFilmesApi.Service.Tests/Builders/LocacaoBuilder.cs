using LocadoraFilmesApi.Service.Application.Dtos;
using LocadoraFilmesApi.Service.Application.ViewModel;
using LocadoraFilmesApi.Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraFilmesApi.Service.Tests.Builders
{
    public class LocacaoBuilder
    {
        private readonly Locacao _locacao;
        private readonly LocacaoDto _locacaoDto;
        private readonly LocacaoCreate _locacaoCreate;
        private readonly LocacaoUpdate _locacaoUpdate;
        private readonly List<Locacao> _listLocacao;
        private readonly List<LocacaoDto> _listLocacaoDto;

        public LocacaoBuilder()
        {
            _locacao = new Locacao()
            {
                Id = 1,
                Id_Cliente = 1,
                Id_Filme = 1,
                DataLocacao = new DateTime(),
                DataDevolucao = new DateTime()
            };

            _locacaoDto = new LocacaoDto()
            {
                Id_Cliente = 1,
                Id_Filme = 1,
                DataLocacao = new DateTime(),
                DataDevolucao = new DateTime()
            };

            _locacaoCreate = new LocacaoCreate()
            {
                Id_Cliente = 1,
                Id_Filme = 1,
                DataLocacao = new DateTime()
            };

            _locacaoUpdate = new LocacaoUpdate()
            {
                Id_Cliente = 1,
                Id_Filme = 1,
                DataLocacao = new DateTime(),
                DataDevolucao = new DateTime()
            };

            _listLocacao = new List<Locacao>() { _locacao, _locacao };

            _listLocacaoDto = new List<LocacaoDto>() { _locacaoDto, _locacaoDto };
        }

        public Locacao Builder() => _locacao;
        public LocacaoDto BuilderDto() => _locacaoDto;
        public LocacaoCreate BuilderCreate() => _locacaoCreate;
        public LocacaoUpdate BuilderUpdate() => _locacaoUpdate;
        public List<Locacao> BuilderList() => _listLocacao;
        public List<LocacaoDto> BuilderListDto() => _listLocacaoDto;
    }
}
