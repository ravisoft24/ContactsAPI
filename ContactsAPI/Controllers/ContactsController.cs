using ContactsAPI.Models;
using ContactsAPI.Ripository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAlllContactsAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById([FromRoute] int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();

            }
            return Ok(contact);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewContact([FromBody] ContactModel contactModel)
        {
            var id = await _contactRepository.AddContactAsync(contactModel);
            return CreatedAtAction(nameof(GetContactById), new { id = id, Controller = "Contacts" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact([FromBody] ContactModel contactModel, [FromRoute] int id)
        {
            var contact = await _contactRepository.UpdateContactAsync(id, contactModel);

            //var contact = await _contactRepository.GetContactByIdAsync(id);
            return Ok(contact);
        }

       [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateContactPatch([FromBody] JsonPatchDocument contactModel, [FromRoute] int id)
        {
            await _contactRepository.UpdateContactPatchAsync(id, contactModel); 
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            await _contactRepository.DeleteContactAsync(id);

            //var contact = await _contactRepository.GetContactByIdAsync(id);
            return Ok();
        }
    }
}
