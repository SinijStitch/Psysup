namespace Psysup.DataContracts.Chats.SendMessage;

public class SendMessageRequest
{
    public Guid ChatId { get; set; }
    public Guid ContactId { get; set; }
    public string Message { get; set; } = string.Empty;
}