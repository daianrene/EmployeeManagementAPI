using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OvertimeController : GenericController<Overtime>
    {
        public OvertimeController(IGenericRepository<Overtime> genericRepository) : base(genericRepository)
        {
        }
    }
}
