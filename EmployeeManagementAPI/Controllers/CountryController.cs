using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : GenericController<Country>
    {
        public CountryController(IGenericRepository<Country> genericRepository) : base(genericRepository)
        {
        }
    }
}
