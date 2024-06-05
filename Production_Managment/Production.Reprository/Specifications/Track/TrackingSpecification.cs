using Production.Core.Entities;
using Production.Core.Specifications.Tracking;
using System.Linq.Expressions;

namespace Production.Reprository.Specifications.Track
{
    public class TrackingSpecification : BaseSpecification<Tracking>
    {
        public TrackingSpecification(TrackingSpecificationParams  specParam) : base(track => string.IsNullOrWhiteSpace(specParam.Search) || track.ProdactName.ToLower().Contains(specParam.Search))
        {
        }
    }
}
