using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Room;
using api.Dtos.User;

namespace api.Dtos.Message
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public RoomDto Room { get; set; } = new RoomDto();
        public int AuthorId { get; set; }
        public UserDto Author { get; set; } = new UserDto();

    }
}