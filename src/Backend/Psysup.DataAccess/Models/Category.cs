namespace Psysup.DataAccess.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Application>? Applications { get; set; }
}