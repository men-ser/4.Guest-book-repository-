using System.ComponentModel.DataAnnotations;

namespace Guest_book.Models
{
    public class RegistrationModel
    {
        [Required]
        [RegularExpression(@"[A-Za-z]{3,8}", ErrorMessage = "логин должен может быть мин 3-8 латинских букви A-z")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
