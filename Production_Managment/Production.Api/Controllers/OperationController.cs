using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Production.Api.Errors;
using Production.Core.DataTransferObject;
using Production.Core.Interface.Service;
using Production.Services;

namespace Production.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IProductOperationService _productOperationService;

        public OperationController(IProductOperationService productOperationService)
        {
            _productOperationService = productOperationService;
        }

        [HttpGet]
        public async Task<ActionResult> GetOperations()
        {
            return Ok(await _productOperationService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOperation(int id)
        {
            var operation = await _productOperationService.GetByIdAsync(id);
            return operation is not null ? Ok(operation) : NotFound(new ApiResponse(404, $"Product with id : {id} Not Found"));
        }

        [HttpPost]
        public async Task<ActionResult> CreateOperation([FromBody] ProductionOperationsDto operationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _productOperationService.CreateAsync(operationDto));

        }

        [HttpPut]
        public async Task<ActionResult> UpdateOperation(int id, [FromBody] ProductionOperationsDto operationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != operationDto.OperationId)
            {
                return BadRequest("Product ID mismatch.");
            }

            try
            {
                var updatedProduct = await _productOperationService.UpdateAsync(operationDto);
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
                await _productOperationService.DeleteAsync(id);
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
