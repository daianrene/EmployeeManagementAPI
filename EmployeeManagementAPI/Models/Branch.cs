using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class Branch : BaseModel
    {
        public int DepartmentId { get; set; }
        [JsonIgnore]
        public Department? Department { get; set; }
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
