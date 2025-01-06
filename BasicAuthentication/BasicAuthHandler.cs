using BasicAuthentication.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;
using System.Text;

namespace BasicAuthentication
{
    public class BasicAuthHandler
    {
        private readonly IUserRepository _userRepository;
        public BasicAuthHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ClaimsPrincipal?> Authenticate(HttpContext context)
        {
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            if (authorizationHeader == null || !authorizationHeader.StartsWith("Basic")) 
            {
                return null;
            }
            
            var base64Credentials = authorizationHeader.Substring("Basic".Length).Trim();
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(base64Credentials));

            var parts = credentials.Split(':');
            var username = parts[0];
            var password = parts[1];

            var user = await _userRepository.ValidateUser(username, password);
            if(user == null)
            {
                return null;
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, password)
            };

            var identity = new ClaimsIdentity(claims);
            var principal = new ClaimsPrincipal(identity);

            return principal;
        }
    }
}
