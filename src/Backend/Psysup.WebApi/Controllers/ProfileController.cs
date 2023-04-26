using MediatR;
using Microsoft.AspNetCore.Mvc;
using Psysup.Domain.Features.Profile.Queries.GetProfile;
using Psysup.WebApi.Filters;

namespace Psysup.WebApi.Controllers;

[PlatformAuthorize]
[Route("[controller]")]
public class ProfileController : ApiControllerBase
{
    private readonly ISender _sender;

    public ProfileController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfileAsync()
    {
        var query = new GetProfileQuery { UserId = UserId };
        var response = await _sender.Send(query);
        return Ok(response);
    }
}