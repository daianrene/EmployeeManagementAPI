using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Employee>> GetAllFull()
        {
            var employees = await _appDbContext.Employees
                .AsNoTracking()
                .Include(t => t.Town)
                .ThenInclude(c => c.City)
                .ThenInclude(c => c.Country)
                .Include(b => b.Branch)
                .ThenInclude(d => d.Department)
                .ThenInclude(gd => gd.GeneralDepartment)
                .ToListAsync();

            return employees;
        }

        public async Task<Employee> GetByIdFull(int id)
        {
            var employee = await _appDbContext.Employees
                .AsNoTracking()
                .Include(t => t.Town)
                .ThenInclude(c => c.City)
                .ThenInclude(c => c.Country)
                .Include(b => b.Branch)
                .ThenInclude(d => d.Department)
                .ThenInclude(gd => gd.GeneralDepartment)
                .FirstOrDefaultAsync(e => e.Id == id);

            return employee!;
        }
    }
}
