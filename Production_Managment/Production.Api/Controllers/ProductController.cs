using Microsoft.AspNetCore.Mvc;
using Production.Api.Errors;
using Production.Core.DataTransferObject;
using Production.Core.Interface.Service;
using Production.Core.Specifications;

namespace Production.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //Retrieve All Operations
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        //Retrieve One Product By Id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id) 
        {
            var product = await _productService.GetByIdAsync(id);
            return product is not null ? Ok(product) : NotFound(new ApiResponse(404, $"Product with id : {id} Not Found"));
        }

        // Create New Product
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _productService.CreateAsync(productDto));
            
        }

        // Update Existing Product
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDto.Id)
            {
                return BadRequest("Product ID mismatch.");
            }

            try
            {
                var updatedProduct = await _productService.UpdateAsync(productDto);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Delete Product
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id) 
        {
            try
            {
                await _productService.DeleteAsync(id);
                var deletedmassage = $"item with id {id} deleted succesfully";
                return Ok(deletedmassage);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        // Search 
        [HttpGet("Search")]
        public async Task<ActionResult> Search([FromQuery] ProductSpecificationParameters searchParams)
        {
            if (string.IsNullOrWhiteSpace(searchParams.Search)) return Ok(BadRequest("Please Enter Product Name"));

            var products = await _productService.SearchProductsAsync(searchParams);

            return Ok(products);
        }
    }
}
