namespace Psysup.DataAccess.Models;

public class Chat
{
    public Guid Id { get; set; }

    public Guid ApplicationId { get; set; }
    public Application? Application { get; set; }

    public IEnumerable<User>? Users { get; set; }
    public IEnumerable<Message>? Messages { get; set; }
}