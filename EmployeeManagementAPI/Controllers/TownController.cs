using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownController : GenericController<Town>
    {
        public TownController(IGenericRepository<Town> genericRepository) : base(genericRepository)
        {
        }
    }
}
