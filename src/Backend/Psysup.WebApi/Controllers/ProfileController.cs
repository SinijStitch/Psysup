using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Psysup.DataContracts.Profile.UpdateProfile;
using Psysup.Domain.Features.Profile.Commands.UpdateProfile;
using Psysup.Domain.Features.Profile.Queries.GetProfile;
using Psysup.WebApi.Filters;

namespace Psysup.WebApi.Controllers;

[PlatformAuthorize]
[Route("[controller]")]
public class ProfileController : ApiControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public ProfileController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfileAsync()
    {
        var query = new GetProfileQuery { UserId = UserId };
        var response = await _sender.Send(query);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProfileAsync([FromForm] UpdateProfileRequest request)
    {
        var command = _mapper.Map<UpdateProfileCommand>(request);
        command.UserId = UserId;
        await _sender.Send(command);
        return NoContent();
    }
}