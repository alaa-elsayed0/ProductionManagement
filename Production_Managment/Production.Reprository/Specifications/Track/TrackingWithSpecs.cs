using Production.Core.Entities;
using Production.Core.Specifications.Tracking;
using System.Linq.Expressions;

namespace Production.Reprository.Specifications.Track
{
    public class TrackingWithSpecs : BaseSpecification<Tracking>
    {
        public TrackingWithSpecs(TrackingSpecificationParams specs) : base(track => string.IsNullOrWhiteSpace(specs.Search) || track.ProdactName.ToLower().Contains(specs.Search))
        {
        }
    }
}
