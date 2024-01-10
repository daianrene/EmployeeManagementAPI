using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanctionTypeController : GenericController<SanctionType>
    {
        public SanctionTypeController(IGenericRepository<SanctionType> genericRepository) : base(genericRepository)
        {
        }
    }
}
