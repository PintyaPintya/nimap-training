using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Models;

namespace WebApiPractice.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly ApplicationDbContext _context;

        public UserController(TokenService tokenService, ApplicationDbContext context)
        {
            _tokenService = tokenService;          
            _context = context;  
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginReq request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            if(user == null) return Unauthorized("Invalid credentials");

            var tokens = _tokenService.GenerateTokens(request.Username);
            return Ok(tokens);
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] RefreshReq refreshRequest, [FromQuery] string id)
        {
            if(string.IsNullOrWhiteSpace(refreshRequest.RefreshToken))
            {
                return BadRequest("Refresh token is required");
            }

            var tokens = _tokenService.GenerateTokens(id);
            return Ok(tokens);
        }
    }
}
