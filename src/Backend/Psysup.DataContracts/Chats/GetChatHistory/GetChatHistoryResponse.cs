namespace Psysup.DataContracts.Chats.GetChatHistory;

public class GetChatHistoryResponse
{
    public IEnumerable<GetChatHistoryResponseItem> Messages { get; set; } = new List<GetChatHistoryResponseItem>();
}