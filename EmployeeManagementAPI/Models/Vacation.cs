using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class Vacation : BaseWorkLicense
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime Endate => StartDate.AddDays(NumberOfDays);
        public int VacationTypeId { get; set; }
        public VacationType? VacationType { get; set; }
    }
}