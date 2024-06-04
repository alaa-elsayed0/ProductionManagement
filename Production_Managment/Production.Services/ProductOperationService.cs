using AutoMapper;
using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Core.Interface.Service;

namespace Production.Services
{
    public class ProductOperationService : IProductOperationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductOperationService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductionOperationsDto> CreateAsync(ProductionOperationsDto operation)
        {
            var operationEntity = _mapper.Map<ProductionOperation>(operation);

            // Add the product entity to the repository
            await _unitOfWork.Repository<ProductionOperation, int>().AddAysnc(operationEntity);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductionOperationsDto>(operationEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var existingOperation = await _unitOfWork.Repository<ProductionOperation, int>().GetAsync(id);

            if (existingOperation == null)
                throw new Exception("Product not found.");

            // Remove the product entity from the repository
            _unitOfWork.Repository<ProductionOperation, int>().Delete(existingOperation);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<ProductionOperationsDto> UpdateAsync(ProductionOperationsDto operation)
        {
            var existingOperation = await _unitOfWork.Repository<ProductionOperation, int>().GetAsync(operation.OperationId);
            if (existingOperation == null)
                throw new Exception("Product not found.");

            _mapper.Map(operation, existingOperation);

            _unitOfWork.Repository<ProductionOperation, int>().Update(existingOperation);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductionOperationsDto>(existingOperation);
        }

        public async Task<IEnumerable<ProductionOperationsDto>> GetAllProducts()
        {
            var operations = await _unitOfWork.Repository<ProductionOperation, int>().GetAllAsync();
            var mappedOperations = _mapper.Map<IReadOnlyList<ProductionOperationsDto>>(operations);

            return mappedOperations;
        }

        public async Task<ProductionOperationsDto> GetByIdAsync(int id)
        {
            var operations = await _unitOfWork.Repository<ProductionOperation, int>().GetAsync(id);
            return _mapper.Map<ProductionOperationsDto>(operations);
        }

    }
}
