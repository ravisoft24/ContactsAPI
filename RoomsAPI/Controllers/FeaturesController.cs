using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsAPI.Repository;
using System.Threading.Tasks;

namespace RoomsAPI.Controllers
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
             var features = _featuresRepository.GetAllFeaturesAsync();  
            return Ok(features);
        }
    }
}
