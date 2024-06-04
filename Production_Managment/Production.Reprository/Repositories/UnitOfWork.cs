using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Reprository.Context;
using System.Collections;

namespace Production.Reprository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _context;
        private readonly Hashtable _repositories;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }
        public async Task<int> CompleteAsync() =>  await _context.SaveChangesAsync();
     
        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            //Check Existance of Repository
            var typeName = typeof(TEntity).Name;
            if (_repositories.ContainsKey(typeName)) return (_repositories[typeName] as GenericRepository<TEntity, TKey>)!;

            //Create repository
            var repo = new GenericRepository<TEntity, TKey>(_context);
            _repositories.Add(typeName, repo);
            return repo;
        }
    }
}
