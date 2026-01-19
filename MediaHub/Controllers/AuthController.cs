using MediaHub.Application.DTOs.Auth;
using MediaHub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static MediaHub.Application.DTOs.Auth.Auth;

namespace MediaHub.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.Register(dto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.Login(dto);
            return result.IsSuccess ? Ok(result) : Unauthorized(result);
        }
    }
}
