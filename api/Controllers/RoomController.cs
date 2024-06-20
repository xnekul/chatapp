using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Room;
using api.Mappers;
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

        public RoomController(ApplicationDBContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var rooms = await _context.Rooms.ToListAsync(); 
            var roomDtos = rooms.Select(s => s.ToRoomDto()).ToList();

            return Ok(roomDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var room = await _context.Rooms.FindAsync(id);

            if(room == null)
            {
                return NotFound();
            }

            return Ok(room.ToRoomDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRoomRequestDto roomDto)
        {
            var roomModel = roomDto.ToRoomFromCreateDto();
            await _context.Rooms.AddAsync(roomModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = roomModel.Id }, roomModel.ToRoomDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoomRequestDto roomDto)
        {
            var roomModel = await _context.Rooms.FindAsync(id);

            if(roomModel == null){
                return NotFound();
            }

            roomModel.Name = roomDto.Name;

            await _context.SaveChangesAsync();

            return Ok(roomModel.ToRoomDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var roomModel = await _context.Rooms.FindAsync(id);

            if(roomModel == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(roomModel); // Remove cannot be async

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}
