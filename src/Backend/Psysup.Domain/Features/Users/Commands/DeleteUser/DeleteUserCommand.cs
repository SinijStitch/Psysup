using MediatR;

namespace Psysup.Domain.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public Guid Id { get; set; }
}