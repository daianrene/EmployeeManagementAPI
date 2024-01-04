using EmployeeManagementAPI.Data.Repositories.IRepositories;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : GenericController<Department>
    {
        public DepartmentController(IGenericRepository<Department> genericRepository) : base(genericRepository)
        {
        }
    }
}
