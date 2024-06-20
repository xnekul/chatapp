using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace api.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public MessageController(ApplicationDBContext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var messages = _context.Messages.ToList();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage([FromRoute] int id){
            var message = _context.Messages.Find(id);
            
            if(message == null)
            {
                return NotFound(message);
            }

            return Ok(message);
        }

    }

}
