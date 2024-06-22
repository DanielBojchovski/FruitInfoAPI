using FruitInfoAPI.Interfaces;
using FruitInfoAPI.Requests;
using FruitInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using FruitInfoAPI.Responses;

namespace FruitInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruityviceController : ControllerBase
    {
        private readonly IFruityviceService _fruityviceService;

        public FruityviceController(IFruityviceService fruityviceService)
        {
            _fruityviceService = fruityviceService;
        }

        [HttpGet("GetFruitByName")]
        public async Task<ActionResult<Fruit?>> GetFruitByName([FromQuery] GetFruitByNameRequest request)
        {
            Fruit? fruit = await _fruityviceService.GetFruitByName(request);
            return fruit is null ? NotFound() : fruit;
        }

        [HttpPost("AddMetadata")]
        public OperationStatusResponse AddMetadata(SaveMetadataRequest request)
        {           
            return _fruityviceService.AddMetadataAsync(request);
        }

        [HttpDelete("RemoveMetadata")]
        public OperationStatusResponse RemoveMetadata([FromQuery] DeleteMetadataRequest request)
        {
            return _fruityviceService.RemoveMetadataAsync(request);             
        }

        [HttpPut("UpdateMetadata")]
        public OperationStatusResponse UpdateMetadata(SaveMetadataRequest request)
        {
            return _fruityviceService.UpdateMetadataAsync(request);
        }
    }
}
