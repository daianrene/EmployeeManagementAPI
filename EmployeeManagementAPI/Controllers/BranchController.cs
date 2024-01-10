using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : GenericController<Branch>
    {
        public BranchController(IGenericRepository<Branch> genericRepository) : base(genericRepository)
        {
        }
    }
}
