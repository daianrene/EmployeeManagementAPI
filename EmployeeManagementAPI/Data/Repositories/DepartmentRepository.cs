using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Data.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
