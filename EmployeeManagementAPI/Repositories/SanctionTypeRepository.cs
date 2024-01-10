using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories
{
    public class SanctionTypeRepository : GenericRepository<SanctionType>
    {
        public SanctionTypeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
