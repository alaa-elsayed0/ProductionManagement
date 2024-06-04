using Production.Core.DataTransferObject;

namespace Production.Core.Interface.Service
{
    public interface IProductOperationService
    {
        Task<ProductionOperationsDto> CreateAsync(ProductionOperationsDto operation);
        Task<ProductionOperationsDto> UpdateAsync(ProductionOperationsDto operation);
        Task DeleteAsync(int id);
        Task<ProductionOperationsDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductionOperationsDto>> GetAllProducts();
    }
}
