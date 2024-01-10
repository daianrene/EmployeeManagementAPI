using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : GenericController<City>
    {
        public CityController(IGenericRepository<City> genericRepository) : base(genericRepository)
        {
        }
    }
}
