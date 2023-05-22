using FluentValidation;
using Psysup.Domain.Enums;

namespace Psysup.Domain.Features.Users.Commands.ChangeUserRoles;

public class ChangeUserRolesValidator : AbstractValidator<ChangeUserRolesCommand>
{
    public ChangeUserRolesValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Roles)
            .NotEmpty()
            .Must(roleNames =>
            {
                var validRoleNames = Enum.GetNames<Roles>();
                return roleNames.All(role => validRoleNames.Contains(role));
            })
            .WithMessage("The role collection has one or more invalid roles.");
    }
}