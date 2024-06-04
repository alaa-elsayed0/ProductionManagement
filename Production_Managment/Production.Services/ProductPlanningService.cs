using AutoMapper;
using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Core.Interface.Service;

namespace Production.Services
{
    public class ProductPlanningService : IProductPlanning
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductPlanningService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductPlanningDto> CreateAsync(ProductPlanningDto plan)
        {
            var mappedplan = _mapper.Map<ProductPlanning>(plan);

            // Add the product entity to the repository
            await _unitOfWork.Repository<ProductPlanning, int>().AddAysnc(mappedplan);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductPlanningDto>(mappedplan);
        }

        public async Task DeleteAsync(int id)
        {
            var existingPlan = await _unitOfWork.Repository<ProductPlanning, int>().GetAsync(id);

            if (existingPlan == null)
                throw new Exception("Product not found.");

            // Remove the product entity from the repository
            _unitOfWork.Repository<ProductPlanning, int>().Delete(existingPlan);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ProductPlanningDto>> GetAllPlans()
        {
            var plans = await _unitOfWork.Repository<ProductPlanning, int>().GetAllAsync();
            var mappedPlans = _mapper.Map<IReadOnlyList<ProductPlanningDto>>(plans);

            return mappedPlans;
        }

        public async Task<ProductPlanningDto> GetByIdAsync(int id)
        {
            var plan = await _unitOfWork.Repository<ProductPlanning, int>().GetAsync(id);
            return _mapper.Map<ProductPlanningDto>(plan);
        }

        public async Task<ProductPlanningDto> UpdateAsync(ProductPlanningDto plan)
        {
            var existingPlan = await _unitOfWork.Repository<ProductPlanning, int>().GetAsync(plan.PlanningId);
            if (existingPlan == null)
                throw new Exception("Product not found.");

            _mapper.Map(plan, existingPlan);

            _unitOfWork.Repository<ProductPlanning, int>().Update(existingPlan);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductPlanningDto>(existingPlan);
        }
    }
}
