using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.DTOs
{
    public class Register
    {

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
                   ErrorMessage = "The password must contain at least 8 characters, one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string? Password { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string? Fullname { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
    }
}
