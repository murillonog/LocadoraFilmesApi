using Dapper;
using LocadoraFilmesApi.Service.Domain.Entities;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Infrastructure.Context;
using LocadoraFilmesApi.Service.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFilmesApi.Service.Infrastructure.Repositories
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        protected new ApplicationDbContext Db;
        protected new DbSet<Filme> DbSet;
        public FilmeRepository(ApplicationDbContext context) : base(context)
        {
            Db = context;
            DbSet = Db.Set<Filme>();
        }

        public async Task<IEnumerable<Filme>> GetNuncaAlugados()
        {
            return await Db.Database.GetDbConnection()
                .QueryAsync<Filme>(QueryFilme.GetNuncaAlugados);
        }

        public async Task<IEnumerable<Filme>> GetTop5Alugados()
        {
            return await Db.Database.GetDbConnection()
                .QueryAsync<Filme>(QueryFilme.GetTop5Alugados);
        }

        public async Task<IEnumerable<Filme>> GetTop3MenosAlugados()
        {
            return await Db.Database.GetDbConnection()
                .QueryAsync<Filme>(QueryFilme.GetTop3MenosAlugados);
        }
    }
}
