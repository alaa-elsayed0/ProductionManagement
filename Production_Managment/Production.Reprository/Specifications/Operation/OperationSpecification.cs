using Production.Core.Entities;
using Production.Core.Specifications.Operation;

namespace Production.Reprository.Specifications.Operation
{
    public class OperationSpecification : BaseSpecification<ProductionOperation>
    {
        public OperationSpecification(OperationSpecificationParameters specs) : base(operate => string.IsNullOrWhiteSpace(specs.Search) || operate.Type.ToLower().Contains(specs.Search))
        {
        }

    }
}
