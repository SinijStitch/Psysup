using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Psysup.DataAccess.Models;
using Psysup.Domain.Constants;

namespace Psysup.Domain.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public async Task SignInAsync(User user)
    {
        var claims = new List<Claim>
        {
            new("id", user.Id.ToString())
        };

        if (user.Roles != null)
            foreach (var role in user.Roles)
                claims.Add(new Claim("role", role.Name));


        var identity = new ClaimsIdentity(claims, CookieConstants.CookieScheme, "id", "role");
        var principle = new ClaimsPrincipal(identity);

        await _contextAccessor.HttpContext.SignInAsync(CookieConstants.CookieScheme, principle);
    }

    public async Task SignOutAsync()
    {
        await _contextAccessor.HttpContext.SignOutAsync(CookieConstants.CookieScheme);
    }
}