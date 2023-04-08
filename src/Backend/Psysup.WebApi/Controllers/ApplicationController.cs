using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Psysup.DataContracts.Application.CreateApplication;
using Psysup.Domain.Features.Application.Commands.CreateApplication;

namespace Psysup.WebApi.Controllers;

[Route("[controller]")]
[Authorize]
public class ApplicationController : ApiControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public ApplicationController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateApplicationRequest request)
    {
        var command = _mapper.Map<CreateApplicationCommand>(request);
        command.UserId = UserId;
        var response = await _sender.Send(command);
        return Ok(response);
    }
}