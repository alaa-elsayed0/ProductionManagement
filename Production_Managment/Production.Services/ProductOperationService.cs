using AutoMapper;
using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Core.Interface.Service;
using Production.Core.Specifications.Operation;
using Production.Reprository.Specifications.Operation;

namespace Production.Services
{
    public class ProductOperationService : IProductOperationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<ProductionOperation, int> _reptository;

        public ProductOperationService(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<ProductionOperation, int> reptository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _reptository = reptository;
        }


        //Create New Product Operation
        public async Task<ProductionOperationsDto> CreateAsync(ProductionOperationsDto operation)
        {
            //Apply Mapping
            var operationEntity = _mapper.Map<ProductionOperation>(operation);

            // Add the product entity to the repository
            await _unitOfWork.Repository<ProductionOperation, int>().AddAysnc(operationEntity);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductionOperationsDto>(operationEntity);
        }


        //Delete Product Operation by Id
        public async Task DeleteAsync(int id)
        {
            var existingOperation = await _unitOfWork.Repository<ProductionOperation, int>().GetAsync(id);

            // Check if Operation Exist
            if (existingOperation == null)
                throw new Exception("Product not found.");

            // Remove the operation entity from the repository
            _unitOfWork.Repository<ProductionOperation, int>().Delete(existingOperation);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();
        }

        //Edit Product Operation
        public async Task<ProductionOperationsDto> UpdateAsync(ProductionOperationsDto operation)
        {
            var existingOperation = await _unitOfWork.Repository<ProductionOperation, int>().GetAsync(operation.Id);

            // Check if Operation Exist
            if (existingOperation == null)
                throw new Exception("Product not found.");

            // Apply Mapping
            _mapper.Map(operation, existingOperation);

            // Update the operation entity from the repository
            _unitOfWork.Repository<ProductionOperation, int>().Update(existingOperation);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductionOperationsDto>(existingOperation);
        }

        // Get All Operations
        public async Task<IEnumerable<ProductionOperationsDto>> GetAllProducts()
        {
            // Get All the operation entity from the repository
            var operations = await _unitOfWork.Repository<ProductionOperation, int>().GetAllAsync();

            // Apply Mapping
            var mappedOperations = _mapper.Map<IReadOnlyList<ProductionOperationsDto>>(operations);

            return mappedOperations;
        }

        // Get One Product Operation By Id
        public async Task<ProductionOperationsDto> GetByIdAsync(int id)
        {
            // Get the operation entity from the repository
            var operations = await _unitOfWork.Repository<ProductionOperation, int>().GetAsync(id);
            return _mapper.Map<ProductionOperationsDto>(operations);
        }


        // Apply Search By Operation Type
        public async Task<IEnumerable<ProductionOperation>> Search(OperationSpecificationParameters specParams)
        {
            var spec = new OperationSpecification(specParams);
            return await _reptository.GetAllWithSpecAsync(spec);
        }
    }
}
