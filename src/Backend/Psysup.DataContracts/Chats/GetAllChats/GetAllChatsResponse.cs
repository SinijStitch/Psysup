namespace Psysup.DataContracts.Chats.GetAllChats;

public class GetAllChatsResponse
{
    public IEnumerable<GetAllChatsResponseItem> Chats { get; set; } = new List<GetAllChatsResponseItem>();
}