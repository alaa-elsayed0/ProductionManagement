using AutoMapper;
using Production.Core.DataTransferObject;
using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Core.Interface.Service;
using Production.Core.Specifications;
using Production.Reprository.Specifications.Product;

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

        //Create New Product
        public async Task<ProductDto> CreateAsync(ProductDto product)
        {
            //Apply Mapping
            var productEntity = _mapper.Map<Product>(product);

            // Add the product entity to the repository
            await _unitOfWork.Repository<Product, int>().AddAysnc(productEntity);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductDto>(productEntity);
        }

        //Delete Product Plan by Id
        public async Task DeleteAsync(int id)
        {
            var existingProduct = await _unitOfWork.Repository<Product, int>().GetAsync(id);

            // Check if Plan Exist
            if (existingProduct == null)
                throw new Exception("Product not found.");

            // Remove the product entity from the repository
            _unitOfWork.Repository<Product, int>().Delete(existingProduct);

            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();
        }

        //Edit Product 
        public async Task<ProductDto> UpdateAsync(ProductDto product)
        {
            var existingProduct = await _unitOfWork.Repository<Product, int>().GetAsync(product.Id);

            // Check if Product Exist
            if (existingProduct == null)
                throw new Exception("Product not found.");


            // Apply Mapping
            _mapper.Map(product, existingProduct);


            // Update the product entity from the repository
            _unitOfWork.Repository<Product, int>().Update(existingProduct);


            // Commit the changes to the database
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductDto>(existingProduct);
        }

        // Get All Products
        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            // Get All the products entity from the repository
            var products = await _unitOfWork.Repository<Product , int>().GetAllAsync();

            // Apply Mapping
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);

            return mappedProducts;
        }

        // Get One Product  By Id
        public async Task<ProductDto> GetByIdAsync(int id)
        {
            // Get the product entity from the repository
            var product = await _unitOfWork.Repository<Product , int>().GetAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        // Apply Search By Product Name
        public async Task<IEnumerable<Product>> SearchProductsAsync(ProductSpecificationParameters specParams)
        {
            var spec = new ProductSpecification(specParams);
            return await _repository.GetAllWithSpecAsync(spec);
        }
    }
}
