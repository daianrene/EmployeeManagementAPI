using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.DTOs
{
    public class AccountBase
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
                   ErrorMessage = "The password must contain at least 8 characters, one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string? Password { get; set; }


    }
}
