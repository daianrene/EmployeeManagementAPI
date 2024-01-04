using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        // Generic Departments
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }

        // Geo
        public DbSet<Town> Towns { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        // Authentication
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }

        // Licences
        DbSet<Vacation> Vacations { get; set; }
        DbSet<VacationType> VacationTypes { get; set; }
        DbSet<Overtime> Overtimes { get; set; }
        DbSet<OvertimeType> OvertimeTypes { get; set; }
        DbSet<Sanction> Sanctions { get; set; }
        DbSet<SanctionType> SanctionTypes { get; set; }
        DbSet<Doctor> Doctors { get; set; }
    }
}
