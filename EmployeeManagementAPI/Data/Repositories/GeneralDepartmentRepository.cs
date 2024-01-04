using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Data.Repositories
{
    public class GeneralDepartmentRepository : GenericRepository<GeneralDepartment>
    {
        private readonly AppDbContext _appDbContext;
        public GeneralDepartmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
