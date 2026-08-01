using System.ComponentModel.DataAnnotations;

namespace Buoi10_DBFirst.Models
{
    public class LoginViewModel
    {
        [Key]
        [MaxLength(20, ErrorMessage = "Username cannot exceed 20 characters.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
