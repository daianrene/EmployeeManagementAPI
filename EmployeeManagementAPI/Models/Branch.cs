namespace EmployeeManagementAPI.Models
{
    public class Branch : BaseModel
    {
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
