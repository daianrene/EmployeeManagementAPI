using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories
{
    public class BranchRepository : GenericRepository<Branch>

    {
        private readonly AppDbContext _appDbContext;
        public BranchRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
