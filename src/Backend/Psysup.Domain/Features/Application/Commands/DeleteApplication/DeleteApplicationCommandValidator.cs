using FluentValidation;

namespace Psysup.Domain.Features.Application.Commands.DeleteApplication;

public class DeleteApplicationCommandValidator : AbstractValidator<DeleteApplicationCommand>
{
    public DeleteApplicationCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.ApplicationId).NotEmpty();
    }
}