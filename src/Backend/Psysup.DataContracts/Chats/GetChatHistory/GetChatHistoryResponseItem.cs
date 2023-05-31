namespace Psysup.DataContracts.Chats.GetChatHistory;

public class GetChatHistoryResponseItem
{
    public Guid Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime CreationDateTime { get; set; }
    public bool IsOwn { get; set; }
}