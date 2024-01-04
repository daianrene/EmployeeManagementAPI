﻿using EmployeeManagementAPI.Data.Repositories;
using EmployeeManagementAPI.DTOs;
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
    }
}