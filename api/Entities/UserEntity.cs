using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Entities
{
    public class UserEntity : IdentityUser
    {
        public string Name { get; set; } = String.Empty;
        public List<RoomEntity> Rooms = new List<RoomEntity>();
        public List<MessageEntity> Messages = new List<MessageEntity>();

    }
}