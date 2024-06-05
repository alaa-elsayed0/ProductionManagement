using Production.Core.Entities;
using Production.Core.Specifications.Product;

namespace Production.Reprository.Specifications.Product
{
    public class ProductWithSpec : BaseSpecification<Product>
    {
        public ProductWithSpec(ProductSpecificationParameters specParams)
            : base(product => string.IsNullOrWhiteSpace(specParams.Search) || product.Name.ToLower().Contains(specParams.Search))
        {

        }
    }
}
