﻿using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericController(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll() => Ok(await _genericRepository.GetAll());


        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = await _genericRepository.GetById(id);
            if (result == null)
                return NotFound();

            await _genericRepository.DeleteById(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
            var result = await _genericRepository.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(T entity)
        {
            if (entity == null)
                return BadRequest();
            await _genericRepository.Insert(entity);
            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, T entity)
        {
            if (entity == null)
                return BadRequest();

            if (entity is BaseModel entityBase && entityBase.Id != id)
                return BadRequest();

            await _genericRepository.Update(id, entity);
            return Ok();
        }
    }
}
