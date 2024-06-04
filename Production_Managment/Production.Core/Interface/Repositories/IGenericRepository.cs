using Production.Core.Entities;

namespace Production.Core.Interface.Repositories
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TKey id);
        Task AddAysnc(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
