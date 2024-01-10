using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationTypeController : GenericController<VacationType>
    {
        public VacationTypeController(IGenericRepository<VacationType> genericRepository) : base(genericRepository)
        {
        }
    }
}
