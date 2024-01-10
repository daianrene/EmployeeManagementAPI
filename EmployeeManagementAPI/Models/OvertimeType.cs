using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class OvertimeType : BaseModel
    {
        [JsonIgnore]
        List<Overtime>? Overtimes { get; set; }
    }
}
