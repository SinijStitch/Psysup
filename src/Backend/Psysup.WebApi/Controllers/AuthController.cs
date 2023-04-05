using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Psysup.DataContracts.Auth.Login;
using Psysup.DataContracts.Auth.Register;
using Psysup.Domain.Features.Auth.Commands.Login;
using Psysup.Domain.Features.Auth.Commands.Register;

namespace Psysup.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
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
}