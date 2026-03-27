using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGymAPI.Data;
using SmartGymAPI.DTOs;
using SmartGymAPI.Services;

namespace SmartGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult>Register(RegisterDTO registerDTO)
        {
            var result = await _service.Register(registerDTO);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var token = await _service.Login(loginDTO);
            return Ok(token);
        }
        [Authorize]
        [HttpGet("secure-data")] 
        public IActionResult GetSecureData() 
        { return Ok("This is protected data"); }
    }
}
