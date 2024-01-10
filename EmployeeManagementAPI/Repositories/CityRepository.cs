using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories
{
    public class CityRepository : GenericRepository<City>

    {
        private readonly AppDbContext _appDbContext;
        public CityRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}