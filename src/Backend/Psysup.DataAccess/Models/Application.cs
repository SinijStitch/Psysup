namespace Psysup.DataAccess.Models;

public class Application
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTimeOffset CreationDateTime { get; set; }
    public DateTimeOffset? EditionDateTime { get; set; }


    public Guid UserId { get; set; }
    public User? User { get; set; }

    public IEnumerable<Category>? Categories { get; set; }
    public IEnumerable<AppliedDoctorApplication>? AppliedDoctorApplications { get; set; }
    public IEnumerable<Chat>? Chats { get; set; }
}