using CozaStore.BusinessLayer.Abstract;
using CozaStore.DtoLayer.ContactDots;
using CozaStore.DtoLayer.MessageDtos;
using CozaStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateContactDto updateContactDto)
        {
            var contact = _contactService.TGetById(updateContactDto.ContactID);

            if (contact == null)
            {
                return NotFound("Belirtilen ID'ye sahip kayıt bulunamadı.");
            }

            contact.PhoneNumber = updateContactDto.PhoneNumber;
            contact.EmailAddress = updateContactDto.EmailAddress;
            contact.Address = updateContactDto.Address;
            contact.MapURL = updateContactDto.MapURL;

            _contactService.TUpdate(contact);

            return Ok(contact);
        }

    }
}
