using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class UpdateMessageRequestDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int AuthorId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}