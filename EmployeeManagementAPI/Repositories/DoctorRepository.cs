using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>
    {
        private readonly AppDbContext _appDbContext;
        public DoctorRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteByEmployeeId(int id)
        {
            var item = await _appDbContext.Doctors.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item != null)
            {
                _appDbContext.Doctors.Remove(item);
                await _appDbContext.SaveChangesAsync();
            }

        }
        public async Task<Doctor?> GetByEmployeeId(int id) => await _appDbContext.Doctors.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
    }
}
