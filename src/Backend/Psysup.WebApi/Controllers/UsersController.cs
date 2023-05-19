using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Psysup.DataContracts.Users.GetUsers;
using Psysup.Domain.Enums;
using Psysup.Domain.Features.Users.Queries.GetUsers;
using Psysup.WebApi.Filters;

namespace Psysup.WebApi.Controllers;

[Route("[controller]")]
[PlatformAuthorize(Roles.Admin)]
public class UsersController : ApiControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public UsersController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync([FromQuery] GetUsersRequest request)
    {
        var query = _mapper.Map<GetUsersQuery>(request);
        query.UserId = UserId;
        var response = await _sender.Send(query);
        return Ok(response);
    }
}