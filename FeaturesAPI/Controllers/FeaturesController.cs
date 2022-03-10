using FeaturesAPI.Models;
using FeaturesAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FeaturesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeaturesRepository _featuresRepository;

        public FeaturesController(IFeaturesRepository featuresRepository)
        {
            _featuresRepository = featuresRepository;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllFeatures()
        {
            var features = await _featuresRepository.GetAllFeatures();
            return Ok(features);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById([FromRoute]int id)
        {
            var feature = await _featuresRepository.GetFeatureById(id);
            if(feature == null)
            {
                return NotFound();
            }
            return Ok(feature);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewFeature([FromBody] FeaturesModel featuresModel)
        {
            var id = await _featuresRepository.AddFeatureAsync(featuresModel);
            return CreatedAtAction(nameof(GetFeatureById), new { id = id, Controller = "Features" }, id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeature([FromBody] FeaturesModel featuresModel, [FromRoute] int id)
        {
            var contact = await _featuresRepository.UpdateFeatureAsync(id, featuresModel);
            return Ok(contact);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateFeaturePatch([FromBody] JsonPatchDocument featuresModel, [FromRoute] int id)
        {
            await _featuresRepository.UpdateFeaturePatchAsync(id, featuresModel);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature([FromRoute] int id)
        {
            await _featuresRepository.DeleteFeatureAsync(id);   
            return Ok();
        }
    }
}
