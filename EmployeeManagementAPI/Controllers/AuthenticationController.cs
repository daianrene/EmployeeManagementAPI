using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAccount _userAccountRepository;

        public AuthenticationController(IUserAccount userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateAsync(Register newUser)
        {
            if (newUser == null) return BadRequest("Model is empty");
            var result = await _userAccountRepository.CreateAsync(newUser);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> SignInAsync(Login user)
        {
            if (user == null) return BadRequest("Model is empty");
            var result = await _userAccountRepository.SignInAsync(user);
            return Ok(result);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshToken token)
        {
            if (token == null) return BadRequest("Model is empty");
            var result = await _userAccountRepository.RefreshTokenAsync(token);
            return Ok(result);
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetUserAsync()
        {
            var users = await _userAccountRepository.GetUsers();
            if (users == null) return NotFound();
            return Ok(users);
        }

        [HttpPut("UpdateUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(ManageUser manageUser)
        {
            var result = await _userAccountRepository.UpdateUser(manageUser);
            return Ok(result);
        }

        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _userAccountRepository.GetRoles();
            if (roles == null) return NotFound();
            return Ok(roles);
        }

        [HttpGet("DeleteUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userAccountRepository.DeleteUser(id);
            return Ok(result);
        }
    }
}
