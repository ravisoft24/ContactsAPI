using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PropertyAPI.Models;
using PropertyAPI.Repository;
using System.Threading.Tasks;

namespace PropertyAPI.Controllers
{
    [Route("api/[controller]")]
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
            var properties = await _propertyRepository.GetAllProperties();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropetyById([FromRoute]int id)
        {
            var property = await _propertyRepository.GetPropetyById(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddProperty([FromBody] PropertyModel propertyModel )
        {
            var id = await _propertyRepository.AddPropertyAsync(propertyModel);
            return CreatedAtAction(nameof(GetPropetyById), new { id = id, Controller = "Property" }, id);
           // return Ok(id);
        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty([FromBody] PropertyModel propertyModel, [FromRoute] int id)
        {
            var property = await _propertyRepository.UpdatePropertyAsync(id, propertyModel);
            return Ok(property);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePropertyPatch([FromBody] JsonPatchDocument contactModel, [FromRoute] int id)
        {
            await _propertyRepository.UpdatePropertyPatchAsync(id, contactModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty([FromRoute] int id)
        {
            await _propertyRepository.DeletePropertyAsync(id);
            //var contact = await _contactRepository.GetContactByIdAsync(id);
            return Ok();
        }
    }
}
