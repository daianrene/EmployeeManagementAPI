namespace EmployeeManagementAPI.Models
{
    public class Country : BaseModel
    {
        public List<City>? Cities { get; set; }
    }
}
