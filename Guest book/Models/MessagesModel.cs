using System.ComponentModel.DataAnnotations;

namespace Guest_book.Models
{
    public class MessagesModel
    {

        
        public User? Name { get; set; }

        public ICollection<Messages>? Messages { get; set; }

        [Required]
        public string Message { get; set; }
        
        public string MessageDate { get; set; }

        public int? UserId { get; set; }


    }
}
