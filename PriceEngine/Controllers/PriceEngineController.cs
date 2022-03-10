using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PriceEngine.Models;
using PriceEngine.Repository;
using System.Threading.Tasks;

namespace PriceEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceEngineController : ControllerBase
    {
        private readonly IPriceEngineRepository _priceEngineRepository;

        public PriceEngineController(IPriceEngineRepository reservationRepository)
        {
            _priceEngineRepository = reservationRepository;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllPrices()
        {
            var prices = await _priceEngineRepository.GetAllPrices();
            return Ok(prices);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPriceById([FromRoute] int id)
        {
            var price = await _priceEngineRepository.GetPriceById(id);
            if (price == null)
            {
                return NotFound();
            }
            return Ok(price);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewPrice([FromBody] PriceEngineModel priceEngineModel)
        {
            var id = await _priceEngineRepository.AddNewPriceAsync(priceEngineModel);
            return CreatedAtAction(nameof(GetPriceById), new { id = id, Controller = "PriceEngine" }, id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrice([FromBody] PriceEngineModel priceEngineModel, [FromRoute] int id)
        {
            var price = await _priceEngineRepository.UpdatePriceAsync(id, priceEngineModel);
            return Ok(price);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePricePatch([FromBody] JsonPatchDocument priceEngineModel, [FromRoute] int id)
        {
            await _priceEngineRepository.UpdatePricePatchAsync(id, priceEngineModel);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrice([FromRoute] int id)
        {
            await _priceEngineRepository.DeletePriceAsync(id);
            return Ok();
        }
    }
}
