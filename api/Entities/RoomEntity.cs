using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class RoomEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
        public List<UserEntity> Users { get; set; } = new List<UserEntity>();

    }
}