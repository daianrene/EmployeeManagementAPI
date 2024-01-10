using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories
{
    public class TownRepository : GenericRepository<Town>

    {
        private readonly AppDbContext _appDbContext;
        public TownRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}