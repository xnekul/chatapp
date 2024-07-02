using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Room;
using api.Entities;
using api.ModelMappers;
using api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace api.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IRepository<RoomEntity> _repository;

        public RoomController(ApplicationDBContext context, IRepository<RoomEntity> repository)
        {
            _context = context;
            _repository = repository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rooms = await _repository.GetAllAsync();
            var roomDtos = rooms.Select(s => s.ToRoomDto()).ToList();

            return Ok(roomDtos);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var room = await _repository.GetByIdAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room.ToRoomDto());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoomRequestDto roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var roomModel = await _repository.CreateAsync(roomDto.ToRoomFromCreateDto());

            return CreatedAtAction(nameof(GetById), new { id = roomModel.Id }, roomModel.ToRoomDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoomRequestDto roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newRoomEntity = roomDto.ToRoomFromUpdateDto(id);
            var updatedRoomEntity = await _repository.UpdateAsync(newRoomEntity);

            if (updatedRoomEntity == null)
            {
                return NotFound();
            }

            return Ok(updatedRoomEntity.ToRoomDto());
        }

        [Authorize]
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
