using MediatR;

namespace Psysup.Domain.Features.Users.Commands.ChangeUserRoles;

public class ChangeUserRolesCommand : IRequest
{
    public Guid Id { get; set; }
    public IEnumerable<string> Roles { get; set; } = new List<string>();
}