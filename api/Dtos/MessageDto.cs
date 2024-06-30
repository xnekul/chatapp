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
        public int RoomId { get; set; }
        public string AuthorId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}