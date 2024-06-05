using Production.Core.Entities;
using Production.Core.Specifications.Product;
using System.Linq.Expressions;

namespace Production.Reprository.Specifications.Product
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductSpecificationParameters specs) : base(product => string.IsNullOrWhiteSpace(specs.Search) || product.Name.ToLower().Contains(specs.Search))
        {
        }
    }
}
