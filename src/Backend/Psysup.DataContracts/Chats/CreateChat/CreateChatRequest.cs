namespace Psysup.DataContracts.Chats.CreateChat;

public class CreateChatRequest
{
    public Guid ContactId { get; set; }
    public Guid ApplicationId { get; set; }
    public string Text { get; set; } = string.Empty;
}