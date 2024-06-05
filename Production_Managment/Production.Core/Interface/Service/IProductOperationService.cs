using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Specifications.Operation;

namespace Production.Core.Interface.Service
{
    public interface IProductOperationService
    {
        Task<ProductionOperationsDto> CreateAsync(ProductionOperationsDto operation);
        Task<ProductionOperationsDto> UpdateAsync(ProductionOperationsDto operation);
        Task DeleteAsync(int id);
        Task<ProductionOperationsDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductionOperationsDto>> GetAllProducts();

        Task<IEnumerable<ProductionOperation>> Search(OperationSpecificationParameters specParams);
    }
}
