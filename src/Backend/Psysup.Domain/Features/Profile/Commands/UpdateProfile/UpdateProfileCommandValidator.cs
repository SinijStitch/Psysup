using FluentValidation;

namespace Psysup.Domain.Features.Profile.Commands.UpdateProfile;

public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.NewPassword).MinimumLength(2);
        RuleFor(x => x.FirstName).MinimumLength(2).MaximumLength(100);
        RuleFor(x => x.LastName).MinimumLength(2).MaximumLength(100);
    }
}