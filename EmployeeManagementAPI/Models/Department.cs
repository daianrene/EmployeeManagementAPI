namespace EmployeeManagementAPI.Models
{
    public class Department : BaseModel
    {
        public int GeneralDepartmentId { get; set; }
        public GeneralDepartment? GeneralDepartment { get; set; }
        public List<Branch>? Branches { get; set; }
    }
}
