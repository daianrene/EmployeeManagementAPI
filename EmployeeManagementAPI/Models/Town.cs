namespace EmployeeManagementAPI.Models
{
    public class Town : BaseModel
    {
        public int CityId { get; set; }
        public City? City { get; set; }

        public List<Employee>? Employees { get; set; }
    }
}
