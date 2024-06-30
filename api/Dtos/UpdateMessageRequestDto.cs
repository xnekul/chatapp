using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class UpdateMessageRequestDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public string AuthorId { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Content must not be empty")]
        [MaxLength(500, ErrorMessage = "Content cannot be over 500 characters")]
        public string Content { get; set; } = string.Empty;
    }
}