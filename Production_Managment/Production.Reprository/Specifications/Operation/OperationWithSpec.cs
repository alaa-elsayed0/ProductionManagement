using Production.Core.Entities;
using Production.Core.Specifications.Operation;

namespace Production.Reprository.Specifications.Operation
{
    public class OperationWithSpec : BaseSpecification<ProductionOperation>
    {
        public OperationWithSpec(OperationSpecificationParameters spec) : base(operate => string.IsNullOrWhiteSpace(spec.Search) || operate.Type.ToLower().Contains(spec.Search))
        {
        }
    }

}
