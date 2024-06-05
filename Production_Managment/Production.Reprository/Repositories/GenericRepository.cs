﻿using Microsoft.EntityFrameworkCore;
using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Core.Interface.Specifications;
using Production.Reprository.Context;
using Production.Reprository.Specifications.Product;

namespace Production.Reprository.Repositories
{
    public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }


        public async Task AddAysnc(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);
        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetAsync(Tkey id) => (await _context.Set<TEntity>().FindAsync(id))!;

        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity> specifications)
                    => await SpecificationsEvaluator<TEntity, Tkey>.BuildQuery(_context.Set<TEntity>(), specifications).ToListAsync();
    }
}
