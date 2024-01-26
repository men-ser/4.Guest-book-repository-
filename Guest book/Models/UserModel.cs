using System.ComponentModel.DataAnnotations;

namespace Guest_book.Models
{
    public class UserModel
    {
            [Required]
            public string Login { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
    }
}
