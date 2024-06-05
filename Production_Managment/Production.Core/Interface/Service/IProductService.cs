using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Specifications;

namespace Production.Core.Interface.Service
{
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(ProductDto product);
        Task<ProductDto> UpdateAsync(ProductDto product);
        Task DeleteAsync(int id);
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<IEnumerable<Product>> SearchProductsAsync(ProductSpecificationParameters specParams);

    }
}
