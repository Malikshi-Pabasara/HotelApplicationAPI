using System.Threading.Tasks;
using HotelApplication.Models;
using HotelApplication.Repository;
using Microsoft.AspNetCore.Mvc;


namespace HotelApplication.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContactsAsync();
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
        public async Task<IActionResult> AddContact([FromBody] ContactModel contactModel)
        {
            var id = await _contactRepository.AddContactAsync(contactModel);
            return CreatedAtAction(nameof(GetContactById), new { id = id, controller = "Contact" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact([FromBody] ContactModel contactModel, [FromRoute] int id)
        {
            await _contactRepository.UpdateContactAsync(id, contactModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            await _contactRepository.DeleteContactAsync(id);
            return Ok();
        }

    }
}

