using Microsoft.AspNetCore.Mvc;
using PerfumeFinder.Api.DTOs;
using PerfumeFinder.Api.Services;

namespace PerfumeFinder.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (!_auth.CreateUser(dto)) return BadRequest(new { message = "Username already exists" });
            return Ok(new { message = "User created" });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _auth.ValidateUser(dto.Username, dto.Password);
            if (user == null) return Unauthorized();
            var token = _auth.GenerateJwtToken(user);
            return Ok(new { token });
        }
    }
}
