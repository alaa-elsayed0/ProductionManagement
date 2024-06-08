using Production.Core.Interface.Specifications;
using System.Linq.Expressions;

namespace Production.Reprository.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        //Where
        public Expression<Func<T, bool>> Criteria { get; }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        //Include
        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = new();
    }
}
