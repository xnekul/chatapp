using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public Room Room { get; set; } = new Room();
        public int AuthorId { get; set; }
        public User Author { get; set; } = new User();

    }
}