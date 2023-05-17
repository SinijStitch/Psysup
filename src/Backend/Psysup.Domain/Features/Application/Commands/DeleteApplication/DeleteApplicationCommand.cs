using MediatR;
using Psysup.Domain.Enums;

namespace Psysup.Domain.Features.Application.Commands.DeleteApplication;

public class DeleteApplicationCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid ApplicationId { get; set; }
    public Roles Roles { get; set; }
}