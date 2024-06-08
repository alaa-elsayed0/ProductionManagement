using AutoMapper;
using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Core.Interface.Service;
using Production.Core.Specifications.Planning;
using Production.Reprository.Specifications.Planning;

namespace Production.Services
{
    public class ProductPlanningService : IProductPlanning
    {
         
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<ProductPlanning, int> _repository;


        public ProductPlanningService(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<ProductPlanning, int> repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        //Create New Product Plan
        public async Task<ProductPlanningDto> CreateAsync(ProductPlanningDto plan)
        {
            //Apply Mapping
            var mappedplan = _mapper.Map<ProductPlanning>(plan);

            // Add the product entity to the repository
            await _unitOfWork.Repository<ProductPlanning, int>().AddAysnc(mappedplan);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductPlanningDto>(mappedplan);
        }

        //Delete Product Plan by Id
        public async Task DeleteAsync(int id)
        {
            var existingPlan = await _unitOfWork.Repository<ProductPlanning, int>().GetAsync(id);

            // Check if Plan Exist
            if (existingPlan == null)
                throw new Exception("Product not found.");

            // Remove the product entity from the repository
            _unitOfWork.Repository<ProductPlanning, int>().Delete(existingPlan);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();
        }

        // Get All Plans
        public async Task<IEnumerable<ProductPlanningDto>> GetAllPlans()
        {
            // Get All the plans entity from the repository
            var plans = await _unitOfWork.Repository<ProductPlanning, int>().GetAllAsync();

            // Apply Mapping
            var mappedPlans = _mapper.Map<IReadOnlyList<ProductPlanningDto>>(plans);

            return mappedPlans;
        }


        // Get One Product Plan By Id
        public async Task<ProductPlanningDto> GetByIdAsync(int id)
        {
            // Get the plan entity from the repository
            var plan = await _unitOfWork.Repository<ProductPlanning, int>().GetAsync(id);
            return _mapper.Map<ProductPlanningDto>(plan);
        }

        //Edit Product Plan
        public async Task<ProductPlanningDto> UpdateAsync(ProductPlanningDto plan)
        {
            var existingPlan = await _unitOfWork.Repository<ProductPlanning, int>().GetAsync(plan.Id);
           
            // Check if Operation Exist
            if (existingPlan == null)
                throw new Exception("Product not found.");


            // Apply Mapping
            _mapper.Map(plan, existingPlan);


            // Update the plan entity from the repository
            _unitOfWork.Repository<ProductPlanning, int>().Update(existingPlan);


            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductPlanningDto>(existingPlan);
        }


        //Apply Search by Product Name
        public async Task<IEnumerable<ProductPlanning>> Search(PlanSpecParams specParams)
        {
            var spec = new PlanningSpecification(specParams);
            return await _repository.GetAllWithSpecAsync(spec);
        }
    }
}
