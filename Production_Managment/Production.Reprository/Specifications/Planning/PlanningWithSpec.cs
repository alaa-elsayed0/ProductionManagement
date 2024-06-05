using Production.Core.Entities;
using Production.Core.Specifications.Planning;
using System.Linq.Expressions;

namespace Production.Reprository.Specifications.Planning
{
    public class PlanningWithSpec : BaseSpecification<ProductPlanning>
    {
        public PlanningWithSpec(PlanSpecParams specs) : base(plan => string.IsNullOrWhiteSpace(specs.Search) || plan.ProductName.ToLower().Contains(specs.Search))
        {
        }
    }
}
