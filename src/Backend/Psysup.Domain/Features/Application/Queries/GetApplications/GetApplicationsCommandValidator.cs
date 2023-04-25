using FluentValidation;
using Psysup.Domain.Enums;

namespace Psysup.Domain.Features.Application.Queries.GetApplications;

public class GetApplicationsCommandValidator : AbstractValidator<GetApplicationsCommand>
{
    public GetApplicationsCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);

        RuleFor(x => x)
            .Must(x => (x.IsPublic && x.Roles.HasFlag(Roles.Doctor)) || x.Roles.HasFlag(Roles.Admin) || !x.IsPublic)
            .WithMessage("Just a doctor can see the public applications.");
    }
}