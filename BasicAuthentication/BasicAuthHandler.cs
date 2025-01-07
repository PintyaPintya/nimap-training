using BasicAuthentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUserRepository _userRepository;
    public BasicAuthHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options, 
        ILoggerFactory logger, 
        UrlEncoder encoder,
        ISystemClock clock,
        IUserRepository userRepository) :base(options, logger, encoder, clock)
    { 
        _userRepository = userRepository;  
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Unauthorized, missing Authorization header");
        }

        string? authorizationHeader = Request.Headers["Authorization"];

        if (string.IsNullOrEmpty(authorizationHeader) ||
            !authorizationHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
        {
            return AuthenticateResult.Fail("Unauthorized, Invalid Authorization header");
        }

        var encodedCredentials = authorizationHeader.Substring("Basic ".Length);
        var decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));

        var credentials = decodedCredentials.Split(":");
        if (credentials.Length != 2)
        {
            return AuthenticateResult.Fail("Unauthorized, Invalid credentials format");
        }

        var username = credentials[0];
        var password = credentials[1];

        var user = await _userRepository.ValidateUser(username, password);
        if (user == null)
        {
            return AuthenticateResult.Fail("Authentication Failed");
        }

        var claims = new[] { 
            new Claim(ClaimTypes.NameIdentifier, username),
            new Claim(ClaimTypes.Role, user.Role)
        };
        var identity = new ClaimsIdentity(claims, "Basic");
        var claimsPrincipal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}