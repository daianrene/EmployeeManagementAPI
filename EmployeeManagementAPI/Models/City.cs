namespace EmployeeManagementAPI.Models
{
    public class City : BaseModel
    {
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public List<Town>? Towns { get; set; }
    }
}