using CozaStore.BusinessLayer.Abstract;
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
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message();
            message.UserEmail = createMessageDto.UserEmail;
            message.UserMessage = createMessageDto.UserMessage;

            _messageService.TInsert(message);
            return Ok("Veri ekleme işlemi gerçekleşti!");
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _messageService.TGetAll();
            return Ok(values);
        }
    }
}
