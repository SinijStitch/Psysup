using MediatR;
using Psysup.DataAccess.Data;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Chats.CreateChat;

namespace Psysup.Domain.Features.Chats.Commands.CreateChat;

public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, CreateChatResponse>
{
    private readonly IPsysupDbContext _dbContext;

    public CreateChatCommandHandler(IPsysupDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateChatResponse> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        var chatId = Guid.NewGuid();

        var message = new Message
        {
            Id = Guid.NewGuid(),
            Text = request.Text,
            CreationDateTime = DateTime.UtcNow,
            ChatId = chatId
        };

        var chat = new Chat
        {
            Id = chatId,
            ApplicationId = request.ApplicationId,
            Messages = new List<Message> { message }
        };

        var charUsers = new List<ChatUser>
        {
            new() { ChatId = chatId, UserId = request.UserId },
            new() { ChatId = chatId, UserId = request.ContactId }
        };

        await _dbContext.Chats.AddAsync(chat, cancellationToken);
        await _dbContext.ChatUsers.AddRangeAsync(charUsers, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CreateChatResponse
        {
            Id = chatId
        };
    }
}