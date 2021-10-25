using System.Threading.Tasks;
using HotelApplication.Repository;
using HotelApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelApplication.Controllers
{
    [Route("api/properties")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllProperties()
        {
            var properties = await _propertyRepository.GetAllPropertiesAsync();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById([FromRoute] int id)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddProperty([FromBody] PropertyModel propertyModel)
        {
            var id = await _propertyRepository.AddPropertyAsync(propertyModel);
            return CreatedAtAction(nameof(GetPropertyById), new { id = id, controller = "Property" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty([FromBody] PropertyModel propertyModel, [FromRoute] int id)
        {
            await _propertyRepository.UpdatePropertyAsync(id, propertyModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty([FromRoute] int id)
        {
            await _propertyRepository.DeletePropertyAsync(id);
            return Ok();
        }

    }
}
