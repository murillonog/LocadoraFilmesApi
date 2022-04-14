using LocadoraFilmesApi.Service.Domain.Interfaces;
using LocadoraFilmesApi.Service.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace LocadoraFilmesApi.Service.Infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity obj)
        {
            var result = await DbSet.AddAsync(obj);
            await Db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> list)
        {
            var List = list.ToList();
            await DbSet.AddRangeAsync(List);
            await Db.SaveChangesAsync();
            return List;
        }

        public async Task Delete(int id)
        {
            var obj = await DbSet.FindAsync(id);
            DbSet.Remove(obj);
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Db.Dispose();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity> Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            await Db.SaveChangesAsync();
            return obj;
        }
    }
}
