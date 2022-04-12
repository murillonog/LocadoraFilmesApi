using LocadoraFilmesApi.Service.Domain.Entities;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Infrastructure.Context;
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
    }
}
