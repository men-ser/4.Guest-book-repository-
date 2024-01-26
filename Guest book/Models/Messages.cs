using System.ComponentModel.DataAnnotations;

namespace Guest_book.Models
{
    public class Messages
    {
        [Key]
        public int Id { get; set; }
        
        public string Message { get; set; }

        public string MessageDate { get; set; }

        public int? UserId { get; set; }
        
        public User? Name { get; set; }

    }
}