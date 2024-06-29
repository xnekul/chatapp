using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Room
{
    public class UpdateRoomRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name name must not be empty")]
        [MaxLength(280, ErrorMessage = "Name cannot be over 280 characters")]
        public string Name { get; set; } = String.Empty;
    }
}