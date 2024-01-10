using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : GenericController<Vacation>
    {
        public VacationController(IGenericRepository<Vacation> genericRepository) : base(genericRepository)
        {
        }
    }
}
