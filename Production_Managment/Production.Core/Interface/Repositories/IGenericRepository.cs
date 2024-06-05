using Production.Core.Entities;
using Production.Core.Interface.Specifications;

namespace Production.Core.Interface.Repositories
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity> specifications);

        Task<TEntity> GetAsync(TKey id);
        Task AddAysnc(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
