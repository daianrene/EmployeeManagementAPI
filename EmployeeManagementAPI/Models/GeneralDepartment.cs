namespace EmployeeManagementAPI.Models
{
    public class GeneralDepartment : BaseModel
    {
        public List<Employee>? Employees { get; set; }
    }
}
