using Microsoft.EntityFrameworkCore;
using Production.Core.Entities;
using Production.Core.Interface.Specifications;
using System.Linq;

namespace Production.Reprository.Specifications.Product
{
    public class SpecificationsEvaluator<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> BuildQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria is not null)
                query = query.Where(specification.Criteria);

            if (specification.IncludeExpressions.Any())
                query = specification.IncludeExpressions
                    .Aggregate(query, (currentquery, expression) => currentquery.Include(expression));


            return query;
        }
    }
}
