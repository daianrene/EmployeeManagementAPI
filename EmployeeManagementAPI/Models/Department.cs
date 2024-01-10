using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class Department : BaseModel
    {
        public int GeneralDepartmentId { get; set; }
        [JsonIgnore]
        public GeneralDepartment? GeneralDepartment { get; set; }
        [JsonIgnore]
        public List<Branch>? Branches { get; set; }
    }
}
