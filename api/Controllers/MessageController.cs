using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Entities;
using api.ModelMappers;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace api.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IRepository<MessageEntity> _repository;

        public MessageController(ApplicationDBContext context, IRepository<MessageEntity> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var messages = await _repository.GetAllAsync();
            var messageDtos = messages.Select(s => s.ToMessageDto()).ToList();
            return Ok(messageDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var message = await _repository.GetByIdAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message.ToMessageDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMessageRequestDto messageDto)
        {
            var messageModel = await _repository.CreateAsync(messageDto.ToMessageFromCreateDto());

            return CreatedAtAction(nameof(GetById), new { id = messageModel.Id }, messageModel.ToMessageDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMessageRequestDto messageDto)
        {
            var newMessageEntity = messageDto.ToMessageFromUpdateDto(id);
            var updatedMessageEntity = await _repository.UpdateAsync(newMessageEntity);

            if (updatedMessageEntity == null)
            {
                return NotFound();
            }

            return Ok(updatedMessageEntity.ToMessageDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool success = await _repository.DeleteAsync(id);

            if (success == false)
            {
                return NotFound();
            }

            return NoContent();
        }

    }

}
