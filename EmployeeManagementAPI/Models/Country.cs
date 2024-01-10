using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class Country : BaseModel
    {
        [JsonIgnore]
        public List<City>? Cities { get; set; }
    }
}
