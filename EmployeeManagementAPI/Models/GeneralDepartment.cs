using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class GeneralDepartment : BaseModel
    {
        [JsonIgnore]
        public List<Department>? Departments { get; set; }
    }
}
