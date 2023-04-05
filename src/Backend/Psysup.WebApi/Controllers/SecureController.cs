using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Psysup.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SecureController : ControllerBase
{
    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult Admin()
    {
        return Ok(new { Status = "Ok" });
    }

    [HttpGet("user")]
    [Authorize(Roles = "User")]
    public IActionResult User()
    {
        return Ok(new { Status = "Ok" });
    }

    [HttpGet]
    [Authorize]
    public IActionResult All()
    {
        return Ok(new { Status = "Ok" });
    }
}