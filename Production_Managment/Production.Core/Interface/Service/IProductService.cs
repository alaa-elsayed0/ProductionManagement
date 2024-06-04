using Production.Core.DataTransferObject;

namespace Production.Core.Interface.Service
{
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(ProductDto product);
        Task<ProductDto> UpdateAsync(ProductDto product);
        Task DeleteAsync(int id);
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllProducts();
    }
}
