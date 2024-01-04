﻿using EmployeeManagementAPI.Data.Repositories.IRepositories;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralDepartmentController : GenericController<GeneralDepartment>
    {
        public GeneralDepartmentController(IGenericRepository<GeneralDepartment> genericRepository) : base(genericRepository)
        {
        }
    }
}
