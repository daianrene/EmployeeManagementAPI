using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories
{
    public class VacationTypeRepository : GenericRepository<VacationType>
    {
        public VacationTypeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
