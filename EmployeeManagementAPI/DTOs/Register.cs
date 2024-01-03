using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.DTOs
{
    public class Register : AccountBase
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string? Fullname { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
    }
}
