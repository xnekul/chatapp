using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class MessageEntity : IEntity
    {
        public int Id { get; set; }
        public required int RoomId { get; set; }
        public required string AuthorId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public RoomEntity? Room { get; init; }
        public UserEntity? Author { get; init; }
    }
}