namespace LocadoraFilmesApi.Service.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);
        Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> list);
        Task Delete(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        Task<TEntity> Update(TEntity obj);
    }
}
