using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Psysup.DataContracts.Chats.CreateChat;
using Psysup.Domain.Features.Chats.Commands.CreateChat;
using Psysup.WebApi.Filters;

namespace Psysup.WebApi.Controllers;

[Route("[controller]")]
[PlatformAuthorize]
public class ChatsController : ApiControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public ChatsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateChatAsync(CreateChatRequest request)
    {
        var command = _mapper.Map<CreateChatCommand>(request);
        command.UserId = UserId;
        var response = await _sender.Send(command);
        return Created($"/chats/{response.Id}", response);
    }
}