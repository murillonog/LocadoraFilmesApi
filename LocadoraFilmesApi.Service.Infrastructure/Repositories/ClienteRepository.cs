using Dapper;
using LocadoraFilmesApi.Service.Domain.Entities;
using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Infrastructure.Context;
using LocadoraFilmesApi.Service.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFilmesApi.Service.Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        protected new ApplicationDbContext Db;
        protected new DbSet<Cliente> DbSet;
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
            Db = context;
            DbSet = Db.Set<Cliente>();
        }

        public async Task<IEnumerable<Cliente>> GetAtrasados()
        {
            return await Db.Database.GetDbConnection()
                .QueryAsync<Cliente>(QueryCliente.GetClientesAtrasados);
        }

        public async Task<IEnumerable<Cliente>> GetSegundoClienteMaisAlugou()
        {
            return await Db.Database.GetDbConnection()
                .QueryAsync<Cliente>(QueryCliente.GetSegundoClienteMaisAlugou);
        }
    }
}
