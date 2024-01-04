using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class Employee : BaseModel
    {
        [Required]
        public string CivilId { get; set; } = string.Empty;
        [Required]
        public string FileNumber { get; set; } = string.Empty;
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string JobName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string TelephoneNumber { get; set; } = string.Empty;
        public string? PhotoUrl { get; set; }
        public string? Other { get; set; }
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }
        public int TownId { get; set; }
        public Town? Town { get; set; }
    }
}
