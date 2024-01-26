
using System.ComponentModel.DataAnnotations;

namespace Guest_book.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public ICollection<Messages>? Messages { get; set; }

    }
}


