using Production.Core.Entities;
using Production.Core.Specifications.StopRecords;

namespace Production.Reprository.Specifications.Record
{
    public class StopRecordsWithSpecs : BaseSpecification<StopRecords>
    {
        public StopRecordsWithSpecs(RecordsSpecificationParams specParam) : base(record => string.IsNullOrWhiteSpace(specParam.Search) || record.ProdactName.ToLower().Contains(specParam.Search))
        {
        }
    }
}
