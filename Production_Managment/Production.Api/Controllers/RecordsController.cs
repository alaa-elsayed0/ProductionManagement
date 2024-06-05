using Microsoft.AspNetCore.Mvc;
using Production.Api.Errors;
using Production.Core.DataTransferObject;
using Production.Core.Interface.Service;
using Production.Core.Specifications.Operation;
using Production.Core.Specifications.StopRecords;
using Production.Services;

namespace Production.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class RecordsController : ControllerBase
    {
        private readonly IStopRecordService _stopRecordService;

        public RecordsController(IStopRecordService stopRecordService)
        {
            _stopRecordService = stopRecordService;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _stopRecordService.GetAllRecords());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _stopRecordService.GetByIdAsync(id);
            return product is not null ? Ok(product) : NotFound(new ApiResponse(404, $"Record with id : {id} Not Found"));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] StopRecordsDto recordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _stopRecordService.CreateAsync(recordDto));

        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] StopRecordsDto recordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recordDto.StopRecordsId)
            {
                return BadRequest("Product ID mismatch.");
            }

            try
            {
                var updatedRecord = await _stopRecordService.UpdateAsync(recordDto);
                return Ok(updatedRecord);
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
                await _stopRecordService.DeleteAsync(id);
                var deletedmassage = $"item with id {id} deleted succesfully";
                return Ok(deletedmassage);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }


        [HttpGet("Search")]
        public async Task<ActionResult> Search([FromQuery] RecordsSpecificationParams searchParams)
        {
            if (string.IsNullOrWhiteSpace(searchParams.Search)) return Ok(BadRequest("Please Enter Product Name"));

            var products = await _stopRecordService.Search(searchParams);

            return Ok(products);
        }
    }
}
