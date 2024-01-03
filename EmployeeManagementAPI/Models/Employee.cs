namespace EmployeeManagementAPI.Models
{
    public class Employee : BaseModel
    {
        public string? CivilId { get; set; }
        public string? FileNumber { get; set; }
        public string? FullName { get; set; }
        public string? JobName { get; set; }
        public string? Address { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Other { get; set; }

        //Relations M-O
        public int GeneralDeparmentId { get; set; }
        public GeneralDepartment? GeneralDeparment { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }
        public int TownId { get; set; }
        public Town? Town { get; set; }
    }
}
