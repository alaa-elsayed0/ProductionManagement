using Production.Core.Entities;
using Production.Core.Specifications.StopRecords;
using System.Linq.Expressions;

namespace Production.Reprository.Specifications.Record
{
    public class StopRecordsSpecification : BaseSpecification<StopRecords>
    {
        public StopRecordsSpecification(RecordsSpecificationParams specs) : base(record => string.IsNullOrWhiteSpace(specs.Search) || record.ProdactName.ToLower().Contains(specs.Search))
        {
        }
    }
}
