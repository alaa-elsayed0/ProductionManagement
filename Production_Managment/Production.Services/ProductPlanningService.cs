using AutoMapper;
using Production.Core.DataTransferObject;
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

        public Task<ProductPlanningDto> CreateAsync(ProductPlanningDto plan)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductPlanningDto>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductPlanningDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductPlanningDto> UpdateAsync(ProductPlanningDto plan)
        {
            throw new NotImplementedException();
        }
    }
}
