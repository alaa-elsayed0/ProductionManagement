using Microsoft.AspNetCore.Mvc;
using Production.Api.Errors;
using Production.Core.DataTransferObject;
using Production.Core.Interface.Service;
using Production.Core.Specifications.Operation;

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

        //Retrieve All Operations
        [HttpGet]
        public async Task<ActionResult> GetOperations()
        {
            return Ok(await _productOperationService.GetAllProducts());
        }

        //Retrieve One Operation By Id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOperation(int id)
        {
            var operation = await _productOperationService.GetByIdAsync(id);
            return operation is not null ? Ok(operation) : NotFound(new ApiResponse(404, $"Product with id : {id} Not Found"));
        }

        // Create New Operation
        [HttpPost]
        public async Task<ActionResult> CreateOperation([FromBody] ProductionOperationsDto operationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _productOperationService.CreateAsync(operationDto));

        }

        // Update Existing Operation
        [HttpPut]
        public async Task<ActionResult> UpdateOperation(int id, [FromBody] ProductionOperationsDto operationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != operationDto.Id)
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

        // Delete Operation
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOperation(int id)
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

        // Search 
        [HttpGet("Search")]
        public async Task<ActionResult> Search([FromQuery] OperationSpecificationParameters searchParams)
        {
            if (string.IsNullOrWhiteSpace(searchParams.Search)) return Ok(BadRequest("Please Enter Operation Name"));

            var products = await _productOperationService.Search(searchParams);

            return Ok(products);
        }
    }
}
