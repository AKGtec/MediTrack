using MediTrack.DTOs;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: api/Messages/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MessageDto>> GetMessageById(int id)
        {
            var message = await _messageService.GetMessageByIdAsync(id);
            if (message == null)
                return NotFound();

            return Ok(message);
        }

        // GET: api/Messages/Conversation?senderId=1&receiverId=2
        [HttpGet("Conversation")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetConversation([FromQuery] int senderId, [FromQuery] int receiverId)
        {
            var messages = await _messageService.GetConversationAsync(senderId, receiverId);
            return Ok(messages);
        }

        // POST: api/Messages
        [HttpPost]
        public async Task<ActionResult<MessageDto>> SendMessage([FromBody] CreateMessageDto dto)
        {
            if (dto == null)
                return BadRequest("Message cannot be null.");

            var sentMessage = await _messageService.SendMessageAsync(dto);
            return CreatedAtAction(nameof(GetMessageById), new { id = sentMessage.MessageId }, sentMessage);
        }

        // PUT: api/Messages/5/Read
        [HttpPut("{id:int}/Read")]
        public async Task<ActionResult<MessageDto>> UpdateMessageStatus(int id, [FromBody] UpdateMessageStatusDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid status update.");

            var updatedMessage = await _messageService.UpdateMessageStatusAsync(id, dto);
            if (updatedMessage == null)
                return NotFound();

            return Ok(updatedMessage);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteMessage(int id)
        {
            var result = await _messageService.DeleteMessageAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
