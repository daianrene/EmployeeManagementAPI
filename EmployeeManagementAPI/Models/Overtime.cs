using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class Overtime : BaseWorkLicense
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int NumberOfDays => (EndDate - StartDate).Days;
        [Required]
        public int OvertimeTypeId { get; set; }
        public OvertimeType? OvertimeType { get; set; }
    }
}
