using MediatR;
using Psysup.DataContracts.Chats.CreateChat;

namespace Psysup.Domain.Features.Chats.Commands.CreateChat;

public class CreateChatCommand : IRequest<CreateChatResponse>
{
    public Guid UserId { get; set; }
    public Guid ContactId { get; set; }
    public Guid ApplicationId { get; set; }
    public string Text { get; set; } = string.Empty;
}