using Microsoft.AspNetCore.Mvc;
using Psysup.DataContracts.Auth.Login;
using Psysup.Domain.Exceptions.Auth;

namespace Psysup.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
    {
        if (string.IsNullOrEmpty(loginRequest.Email)) throw new IncorrectEmailOrPasswordException();

        return Ok("Ok");
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterAsync()
    {
        return Ok("asd");
    }
}