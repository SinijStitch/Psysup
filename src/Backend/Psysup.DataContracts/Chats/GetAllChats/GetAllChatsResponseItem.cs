namespace Psysup.DataContracts.Chats.GetAllChats;

public class GetAllChatsResponseItem
{
    public Guid Id { get; set; }
    public Guid ContactId { get; set; }
    public string ContactFullName { get; set; } = string.Empty;
    public string ContactImagePath { get; set; } = string.Empty;
}