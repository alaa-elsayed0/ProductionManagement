using System.Linq.Expressions;

namespace Production.Core.Interface.Specifications
{
    public interface ISpecifications<T>
    {
        //Where Criteria
        public Expression<Func<T, bool>> Criteria { get; }

        //Include 
        public List<Expression<Func<T, object>>> IncludeExpressions { get; }
    }
}
