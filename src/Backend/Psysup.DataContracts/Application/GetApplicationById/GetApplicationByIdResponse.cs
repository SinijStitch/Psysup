namespace Psysup.DataContracts.Application.GetApplicationById;

public class GetApplicationByIdResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTimeOffset CreationDateTime { get; set; }
    public DateTimeOffset? EditionDateTime { get; set; }

    public IEnumerable<GetApplicationByIdCategory> Categories { get; set; } = new List<GetApplicationByIdCategory>();
}