namespace Psysup.DataAccess.Models;

public class ApplicationCategory
{
    public Guid ApplicationsId { get; set; }
    public Guid CategoriesId { get; set; }

    public Application? Application { get; set; }
    public Category? Category { get; set; }
}