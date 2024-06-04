using Production.Core.DataTransferObject;

namespace Production.Core.Interface.Service
{
    public interface IProductPlanning
    {
        Task<ProductPlanningDto> CreateAsync(ProductPlanningDto plan);
        Task<ProductPlanningDto> UpdateAsync(ProductPlanningDto plan);
        Task DeleteAsync(int id);
        Task<ProductPlanningDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductPlanningDto>> GetAllProducts();
    }
}
