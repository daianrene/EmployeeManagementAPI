using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Repositories
{
    public class OvertimeRepository : GenericRepository<Overtime>
    {
        private readonly AppDbContext _appDbContext;
        public OvertimeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteByEmployeeId(int id)
        {
            var item = await _appDbContext.Overtimes.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item != null)
            {
                _appDbContext.Overtimes.Remove(item);
                await _appDbContext.SaveChangesAsync();
            }

        }

        public async Task<List<Overtime>> GetAllWithType() => await _appDbContext.Overtimes
            .AsNoTracking()
            .Include(t => t.OvertimeType)
            .ToListAsync();
        public async Task<Overtime?> GetByEmployeeId(int id) => await _appDbContext.Overtimes.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
    }
}
