using FluentValidation;

namespace Psysup.Domain.Features.Profile.Commands.UpdateProfile;

public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.NewPassword).MinimumLength(2);
    }
}