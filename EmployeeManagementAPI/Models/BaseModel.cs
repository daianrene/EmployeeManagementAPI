using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
