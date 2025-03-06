using CozaStore.BusinessLayer.Abstract;
using CozaStore.DtoLayer.MessageDtos;
using CozaStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList() {
            var values = _messageService.TGetAll();
            return Ok(values);
        }

        [HttpDelete]
        public IActionResult MessageDelete(int id)
        {
            _messageService.TDelete(id);
            return Ok("Veri silme işlemi gerçekleşti!");
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
    }
}
