using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Repositories
{
    public class VacationRepository : GenericRepository<Vacation>
    {
        private readonly AppDbContext _appDbContext;
        public VacationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteByEmployeeId(int id)
        {
            var item = await _appDbContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item != null)
            {
                _appDbContext.Vacations.Remove(item);
                await _appDbContext.SaveChangesAsync();
            }

        }

        public async Task<List<Vacation>> GetAllWithType() => await _appDbContext.Vacations
            .AsNoTracking()
            .Include(t => t.VacationType)
            .ToListAsync();
        public async Task<Vacation?> GetByEmployeeId(int id) => await _appDbContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
    }
}
