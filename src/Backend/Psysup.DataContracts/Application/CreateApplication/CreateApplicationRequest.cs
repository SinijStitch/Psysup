namespace Psysup.DataContracts.Application.CreateApplication;

public class CreateApplicationRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}