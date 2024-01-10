using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : GenericController<Employee>
    {
        private readonly EmployeeRepository _er;

        public EmployeeController(IGenericRepository<Employee> genericRepository, EmployeeRepository er) : base(genericRepository)
        {
            _er = er;
        }

        [HttpGet("AllFull")]
        public async Task<IActionResult> GetAllFull() => Ok(await _er.GetAllFull());

        [HttpGet("Full/{id}")]
        public async Task<IActionResult> GetByIdFull(int id) => Ok(await _er.GetByIdFull(id));


    }
}
