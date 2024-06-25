using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CreateMessageRequestDto
    {
        public int RoomId { get; set; }
        public int AuthorId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}