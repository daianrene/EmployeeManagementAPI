using EmployeeManagementAPI.Data.Repositories.IRepositories;
using EmployeeManagementAPI.DTOs;
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

        [HttpGet]
        [Authorize]
        public ActionResult<List<String>> Get()
        {
            return Ok(new List<string>() { "hola", "como", "estas" });
        }

        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<String>> GetAdmin()
        {
            return Ok(new List<string>() { "hola", "como", "admin" });
        }

        [HttpGet("User")]
        [Authorize(Roles = "User")]
        public ActionResult<List<String>> GetUser()
        {
            return Ok(new List<string>() { "hola", "como", "user" });
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
    }
}
