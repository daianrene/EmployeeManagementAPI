using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class Town : BaseModel
    {
        public int CityId { get; set; }
        [JsonIgnore]
        public City? City { get; set; }
        [JsonIgnore]

        public List<Employee>? Employees { get; set; }
    }
}
