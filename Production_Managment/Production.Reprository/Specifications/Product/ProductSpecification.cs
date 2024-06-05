using Production.Core.Specifications;

namespace Production.Reprository.Specifications.Product
{
    public class ProductSpecification : BaseSpecification<Core.Entities.Product>
    {
        public ProductSpecification(ProductSpecificationParameters specs) : base(product => string.IsNullOrWhiteSpace(specs.Search) || product.Name.ToLower().Contains(specs.Search))
        {
        }
    }
}
