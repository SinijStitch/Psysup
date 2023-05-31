using AutoMapper;
using Psysup.DataContracts.Chats.CreateChat;
using Psysup.Domain.Features.Chats.Commands.CreateChat;

namespace Psysup.Domain.Mappings;

public class ChatsProfile : Profile
{
    public ChatsProfile()
    {
        CreateMap<CreateChatRequest, CreateChatCommand>();
    }
}