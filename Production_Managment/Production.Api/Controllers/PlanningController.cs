using Microsoft.AspNetCore.Mvc;
using Production.Api.Errors;
using Production.Core.DataTransferObject;
using Production.Core.Interface.Service;
using Production.Services;

namespace Production.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanningController : ControllerBase
    {
        private readonly IProductPlanning _productPlanning;

        public PlanningController(IProductPlanning productPlanning)
        {
            _productPlanning = productPlanning;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _productPlanning.GetAllPlans());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _productPlanning.GetByIdAsync(id);
            return product is not null ? Ok(product) : NotFound(new ApiResponse(404, $"Product with id : {id} Not Found"));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductPlanningDto planningDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _productPlanning.CreateAsync(planningDto));

        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductPlanningDto planningDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != planningDto.PlanningId)
            {
                return BadRequest("Product ID mismatch.");
            }

            try
            {
                var updatedProduct = await _productPlanning.UpdateAsync(planningDto);
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
                await _productPlanning.DeleteAsync(id);
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
