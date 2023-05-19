namespace Psysup.DataContracts.Users.GetUsers;

public class GetUsersResponseItem
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? ImagePath { get; set; }
    public IEnumerable<string> Roles { get; set; } = new List<string>();
}