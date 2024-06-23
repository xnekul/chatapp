using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Room;
using api.Entities;
using api.ModelMappers;
using api.Repositories;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _repository.GetAllAsync();
            var roomDtos = rooms.Select(s => s.ToRoomDto()).ToList();

            return Ok(roomDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var room = await _repository.GetByIdAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room.ToRoomDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRoomRequestDto roomDto)
        {
            var roomModel = await _repository.CreateAsync(roomDto.ToRoomFromCreateDto());

            return CreatedAtAction(nameof(GetById), new { id = roomModel.Id }, roomModel.ToRoomDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoomRequestDto roomDto)
        {
            var newRoomEntity = roomDto.ToRoomFromUpdateDto(id);
            var updatedRoomEntity = await _repository.UpdateAsync(newRoomEntity);

            if (updatedRoomEntity == null)
            {
                return NotFound();
            }

            return Ok(updatedRoomEntity.ToRoomDto());
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
