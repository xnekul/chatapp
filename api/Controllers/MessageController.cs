using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Entities;
using api.Extensions;
using api.ModelMappers;
using api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IRepository<MessageEntity> _repository;

        public MessageController(ApplicationDBContext context, IRepository<MessageEntity> repository, UserManager<UserEntity> userManager)
        {
            _context = context;
            _repository = repository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var messages = await _repository.GetAllAsync();
            var messageDtos = messages.Select(s => s.ToMessageDto()).ToList();
            return Ok(messageDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var message = await _repository.GetByIdAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message.ToMessageDto());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMessageRequestDto messageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var messageModel = await _repository.CreateAsync(messageDto.ToMessageFromCreateDto(appUser.Id));

            return CreatedAtAction(nameof(GetById), new { id = messageModel.Id }, messageModel.ToMessageDto());
        }

        [Authorize]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMessageRequestDto messageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newMessageEntity = messageDto.ToMessageFromUpdateDto(id);
            var updatedMessageEntity = await _repository.UpdateAsync(newMessageEntity);

            if (updatedMessageEntity == null)
            {
                return NotFound();
            }

            return Ok(updatedMessageEntity.ToMessageDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool success = await _repository.DeleteAsync(id);

            if (success == false)
            {
                return NotFound();
            }

            return NoContent();
        }

    }

}
