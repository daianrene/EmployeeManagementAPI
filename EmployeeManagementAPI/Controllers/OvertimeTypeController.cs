using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OvertimeTypeController : GenericController<OvertimeType>
    {
        public OvertimeTypeController(IGenericRepository<OvertimeType> genericRepository) : base(genericRepository)
        {
        }
    }
}
