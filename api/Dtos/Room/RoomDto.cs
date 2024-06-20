using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Message;
using api.Dtos.User;

namespace api.Dtos.Room
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name {get; set; } = String.Empty;
        public List<MessageDto> Messages { get; set; } = new List<MessageDto>();
        public List<UserDto> Users { get; set; } = new List<UserDto>();

    }
}