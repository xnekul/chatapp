using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<RoomEntity> Rooms = new List<RoomEntity>();
    }
}