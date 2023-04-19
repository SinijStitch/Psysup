using MediatR;
using Psysup.DataContracts.Application.CreateApplication;

namespace Psysup.Domain.Features.Application.Commands.CreateApplication;

public class CreateApplicationCommand : IRequest<CreateApplicationResponse>
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public IEnumerable<string> Categories { get; set; } = new List<string>();
}