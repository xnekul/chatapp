using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom([FromRoute] int id){
            var room = _context.Rooms.Find(id);
            
            if(room == null)
            {
                return NotFound(room);
            }

            return Ok(room);
        }

    }

}
