using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class MessageEntity : IEntity
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public RoomEntity Room { get; set; } = new RoomEntity();
        public int AuthorId { get; set; }
        public UserEntity Author { get; set; } = new UserEntity();

    }
}