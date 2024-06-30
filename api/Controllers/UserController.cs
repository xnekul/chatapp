using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

    }

}
