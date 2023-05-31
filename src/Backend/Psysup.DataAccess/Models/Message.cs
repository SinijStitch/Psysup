namespace Psysup.DataAccess.Models;

public class Message
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime CreationDateTime { get; set; }

    public Guid ChatId { get; set; }
    public Chat? Chat { get; set; }
}