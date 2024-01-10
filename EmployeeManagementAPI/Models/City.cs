using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class City : BaseModel
    {
        public int CountryId { get; set; }
        [JsonIgnore]
        public Country? Country { get; set; }
        [JsonIgnore]
        public List<Town>? Towns { get; set; }
    }
}