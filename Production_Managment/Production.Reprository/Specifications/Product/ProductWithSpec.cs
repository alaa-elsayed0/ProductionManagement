using Production.Core.Specifications;

namespace Production.Reprository.Specifications.Product
{
    public class ProductWithSpec : BaseSpecification<Core.Entities.Product>
    {
        public ProductWithSpec(ProductSpecificationParameters specParams)
            : base(product => string.IsNullOrWhiteSpace(specParams.Search) || product.Name.ToLower().Contains(specParams.Search))
        {

        }
    }
}
