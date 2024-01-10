using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanctionController : GenericController<Sanction>
    {
        public SanctionController(IGenericRepository<Sanction> genericRepository) : base(genericRepository)
        {
        }
    }
}
