using Microsoft.AspNetCore.Mvc;
using Production.Api.Errors;
using Production.Core.DataTransferObject;
using Production.Core.Interface.Service;
using Production.Core.Specifications;
using Production.Core.Specifications.Planning;
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

        //Retrieve All Plans
        [HttpGet]
        public async Task<ActionResult> GetPlans()
        {
            return Ok(await _productPlanning.GetAllPlans());
        }

        //Retrieve One Plan By Id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPlan(int id)
        {
            var product = await _productPlanning.GetByIdAsync(id);
            return product is not null ? Ok(product) : NotFound(new ApiResponse(404, $"Plan with id : {id} Not Found"));
        }

        // Create New Plan
        [HttpPost]
        public async Task<ActionResult> CreatePlan([FromBody] ProductPlanningDto planningDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _productPlanning.CreateAsync(planningDto));

        }

        // Update Existing Plan
        [HttpPut]
        public async Task<ActionResult> UpdatePlan(int id, [FromBody] ProductPlanningDto planningDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != planningDto.Id)
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

        // Delete Plan
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlan(int id)
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

        // Search 
        [HttpGet("Search")]
        public async Task<ActionResult> Search([FromQuery] PlanSpecParams searchParams)
        {
            if (string.IsNullOrWhiteSpace(searchParams.Search)) return Ok(BadRequest("Please Enter Product Name"));

            var products = await _productPlanning.Search(searchParams);

            return Ok(products);
        }
    }
}
