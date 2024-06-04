using Microsoft.AspNetCore.Mvc;
using Production.Api.Errors;
using Production.Core.DataTransferObject;
using Production.Core.Interface.Service;
using Production.Services;

namespace Production.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingService _trackingService;

        public TrackingController(ITrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _trackingService.GetAllTracks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var tracking = await _trackingService.GetByIdAsync(id);
            return tracking is not null ? Ok(tracking) : NotFound(new ApiResponse(404, $"Product with id : {id} Not Found"));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] TrackingDto trackingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _trackingService.CreateAsync(trackingDto));

        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] TrackingDto trackingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trackingDto.TrackingId)
            {
                return BadRequest("Product ID mismatch.");
            }

            try
            {
                var updatedProduct = await _trackingService.UpdateAsync(trackingDto);
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
                await _trackingService.DeleteAsync(id);
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
