﻿using Microsoft.AspNetCore.Mvc;
using Production.Api.Errors;
using Production.Core.DataTransferObject;
using Production.Core.Interface.Service;

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

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id) 
        {
            var product = await _productService.GetByIdAsync(id);
            return product is not null ? Ok(product) : NotFound(new ApiResponse(404, $"Product with id : {id} Not Found"));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _productService.CreateAsync(productDto));
            
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDto.ProductId)
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
    }
}