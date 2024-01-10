using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories
{
    public class OvertimeTypeRepository : GenericRepository<OvertimeType>
    {
        public OvertimeTypeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
