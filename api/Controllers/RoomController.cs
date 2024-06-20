using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Room;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll(){
            var rooms = _context.Rooms.ToList();
            var roomDtos = rooms.Select(s => s.ToRoomDto()).ToList();

            return Ok(roomDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var room = _context.Rooms.Find(id);

            if(room == null)
            {
                return NotFound();
            }

            return Ok(room.ToRoomDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRoomRequestDto roomDto)
        {
            var roomModel = roomDto.ToRoomFromCreateDto();
            _context.Rooms.Add(roomModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = roomModel.Id }, roomModel.ToRoomDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateRoomRequestDto roomDto)
        {
            var roomModel = _context.Rooms.Find(id);

            if(roomModel == null){
                return NotFound();
            }

            roomModel.Name = roomDto.Name;

            _context.SaveChanges();

            return Ok(roomModel.ToRoomDto());
        }

    }

}
