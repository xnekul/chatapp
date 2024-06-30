using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Room;

namespace api.Dtos.User
{
    public class UserDto
    {
        public required string Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<RoomDto> Rooms = new List<RoomDto>();
    }
}