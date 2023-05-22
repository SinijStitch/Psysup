using FluentValidation;

namespace Psysup.Domain.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}