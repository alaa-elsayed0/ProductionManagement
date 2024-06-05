using AutoMapper;
using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Core.Interface.Service;
using Production.Core.Specifications.Product;
using Production.Reprository.Context;
using Production.Reprository.Specifications;

namespace Production.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Product,int> _repository;



        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Product, int> repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ProductDto> CreateAsync(ProductDto product)
        {
            var productEntity = _mapper.Map<Product>(product);

            // Add the product entity to the repository
            await _unitOfWork.Repository<Product, int>().AddAysnc(productEntity);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductDto>(productEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var existingProduct = await _unitOfWork.Repository<Product, int>().GetAsync(id);

            if (existingProduct == null)
                throw new Exception("Product not found.");

            // Remove the product entity from the repository
            _unitOfWork.Repository<Product, int>().Delete(existingProduct);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<ProductDto> UpdateAsync(ProductDto product)
        {
            var existingProduct = await _unitOfWork.Repository<Product, int>().GetAsync(product.ProductId);
            if (existingProduct == null)
                throw new Exception("Product not found.");
           
            _mapper.Map(product, existingProduct);

            _unitOfWork.Repository<Product, int>().Update(existingProduct);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductDto>(existingProduct);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _unitOfWork.Repository<Product , int>().GetAllAsync();
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);

            return mappedProducts;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Repository<Product , int>().GetAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(ProductSpecificationParameters specParams)
        {
            var spec = new ProductSpecification(specParams);
            return await _repository.GetAllWithSpecAsync(spec);
        }
    }
}
