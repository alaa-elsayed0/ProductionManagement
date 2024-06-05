using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Specifications;
using Production.Core.Specifications.Planning;

namespace Production.Core.Interface.Service
{
    public interface IProductPlanning
    {
        Task<ProductPlanningDto> CreateAsync(ProductPlanningDto plan);
        Task<ProductPlanningDto> UpdateAsync(ProductPlanningDto plan);
        Task DeleteAsync(int id);
        Task<ProductPlanningDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductPlanningDto>> GetAllPlans();

        Task<IEnumerable<ProductPlanning>> Search(PlanSpecParams specParams);

    }
}
