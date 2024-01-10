using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class SanctionType : BaseModel
    {
        [JsonIgnore]
        public List<Sanction>? Sanctions { get; set; }
    }
}
