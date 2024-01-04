namespace EmployeeManagementAPI.Models
{
    public class GeneralDepartment : BaseModel
    {
        public List<Department>? Departments { get; set; }
    }
}
