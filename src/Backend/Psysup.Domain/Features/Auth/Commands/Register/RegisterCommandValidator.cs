using FluentValidation;

namespace Psysup.Domain.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        //RuleFor(x => x.Password).Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(2);
    }
}