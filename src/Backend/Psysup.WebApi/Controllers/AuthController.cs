using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Psysup.DataContracts.Auth.Login;
using Psysup.DataContracts.Auth.Register;
using Psysup.Domain.Features.Auth.Commands.Login;
using Psysup.Domain.Features.Auth.Commands.Logout;
using Psysup.Domain.Features.Auth.Commands.Register;
using Psysup.WebApi.Filters;

namespace Psysup.WebApi.Controllers;

[Route("[controller]")]
public class AuthController : ApiControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public AuthController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var command = _mapper.Map<LoginCommand>(request);
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [PlatformAuthorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> LogoutAsync()
    {
        var command = new LogoutCommand();
        await _sender.Send(command);
        return Ok();
    }
}