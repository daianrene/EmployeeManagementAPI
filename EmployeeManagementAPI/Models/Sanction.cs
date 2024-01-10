using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class Sanction : BaseWorkLicense
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Punishment { get; set; } = string.Empty;
        [Required]
        public DateTime PunishmentDate { get; set; }
        public int SanctionTypeId { get; set; }
        public SanctionType? SanctionType { get; set; }
    }
}