using System.Threading.Tasks;
using HotelApplication.Models;
using HotelApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelApplication.Controllers
{
    [Route("api/features")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureRepository _featureRepository;
        public FeatureController(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllFeatures()
        {
            var features = await _featureRepository.GetAllFeaturesAsync();
            return Ok(features);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById([FromRoute] int id)
        {
            var feature = await _featureRepository.GetFeatureByIdAsync(id);
            if (feature == null)
            {
                return NotFound();
            }
            return Ok(feature);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddFeature([FromBody] FeatureModel featureModel)
        {
            var id = await _featureRepository.AddFeatureAsync(featureModel);
            return CreatedAtAction(nameof(GetFeatureById), new { id = id, controller = "Feature" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeature([FromBody] FeatureModel featureModel, [FromRoute] int id)
        {
            await _featureRepository.UpdateFeatureAsync(id, featureModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature([FromRoute] int id)
        {
            await _featureRepository.DeleteFeatureAsync(id);
            return Ok();
        }

    }
}
