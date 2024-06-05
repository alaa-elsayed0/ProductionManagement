using Production.Core.Entities;
using Production.Core.Specifications.Planning;
using System.Linq.Expressions;

namespace Production.Reprository.Specifications.Planning
{
    public class PlanningSpecification : BaseSpecification<ProductPlanning>
    {
        public PlanningSpecification(PlanSpecParams specs) : base(plan => string.IsNullOrWhiteSpace(specs.Search) || plan.ProductName.ToLower().Contains(specs.Search))
        {
        }
    }
}
