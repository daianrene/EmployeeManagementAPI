namespace EmployeeManagementAPI.Models
{
    public class ApplicationUser : BaseModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
