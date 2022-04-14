using Dapper;
using LocadoraFilmesApi.Service.Domain.Entities;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Infrastructure.Context;
using LocadoraFilmesApi.Service.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFilmesApi.Service.Infrastructure.Repositories
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        protected new ApplicationDbContext Db;
        protected new DbSet<Locacao> DbSet;
        public LocacaoRepository(ApplicationDbContext context) : base(context)
        {
            Db = context;
            DbSet = Db.Set<Locacao>();
        }

        public async Task<IEnumerable<Locacao>> GetAllLocacoes()
        {
            return await Db.Database.GetDbConnection()
                .QueryAsync<Locacao>(QueryLocacao.GetLocacoes);
        }
    }
}
