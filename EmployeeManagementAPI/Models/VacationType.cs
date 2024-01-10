using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class VacationType : BaseModel
    {
        [JsonIgnore]
        public List<Vacation>? Vacations { get; set; }
    }
}
