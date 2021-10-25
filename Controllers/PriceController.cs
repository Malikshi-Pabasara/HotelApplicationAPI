using System;
using System.Threading.Tasks;
using HotelApplication.Models;
using HotelApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelApplication.Controllers
{
    [Route("api/prices")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceRepository _priceRepository;
        public PriceController(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllPrices()
        {
            var prices = await _priceRepository.GetAllPricesAsync();
            return Ok(prices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPriceById([FromRoute] int id)
        {
            var price = await _priceRepository.GetPriceByIdAsync(id);
            if (price == null)
            {
                return NotFound();
            }
            return Ok(price);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddPrice([FromBody] PriceModel priceModel)
        {
            var id = await _priceRepository.AddPriceAsync(priceModel);
            return CreatedAtAction(nameof(GetPriceById), new { id = id, controller = "Price" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrice([FromBody] PriceModel priceModel, [FromRoute] int id)
        {
            await _priceRepository.UpdatePriceAsync(id, priceModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrice([FromRoute] int id)
        {
            await _priceRepository.DeletePriceAsync(id);
            return Ok();
        }

    }
}
