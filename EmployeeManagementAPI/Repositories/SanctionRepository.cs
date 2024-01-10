using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Repositories
{
    public class SanctionRepository : GenericRepository<Sanction>
    {
        private readonly AppDbContext _appDbContext;
        public SanctionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteByEmployeeId(int id)
        {
            var item = await _appDbContext.Sanctions.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item != null)
            {
                _appDbContext.Sanctions.Remove(item);
                await _appDbContext.SaveChangesAsync();
            }

        }

        public async Task<List<Sanction>> GetAllWithType() => await _appDbContext.Sanctions
            .AsNoTracking()
            .Include(t => t.SanctionType)
            .ToListAsync();
        public async Task<Sanction?> GetByEmployeeId(int id) => await _appDbContext.Sanctions.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
    }
}
