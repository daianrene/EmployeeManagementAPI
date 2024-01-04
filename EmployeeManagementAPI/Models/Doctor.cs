using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class Doctor : BaseWorkLicense
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string MedicalDiagnose { get; set; } = string.Empty;
        [Required]
        public string MedicalRecommendation { get; set; } = string.Empty;
    }
}
