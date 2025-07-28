using LinkDev.OrderManagementSystem.Application.Abstraction.Contracts;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Users;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.OrderManagementSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var token = await _authService.RegisterAsync(dto);
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { Message = "Invalid username or password" });

            return Ok(new { Token = token });
        }
    }
}

