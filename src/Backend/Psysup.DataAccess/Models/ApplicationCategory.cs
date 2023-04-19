namespace Psysup.DataAccess.Models;

public class ApplicationCategory
{
    public Guid ApplicationId { get; set; }
    public Guid CategoryId { get; set; }

    public Application? Application { get; set; }
    public Category? Category { get; set; }
}