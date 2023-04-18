using FluentValidation;

namespace Psysup.Domain.Features.Application.Queries.GetApplications;

public class GetApplicationsCommandValidator : AbstractValidator<GetApplicationsCommand>
{
    public GetApplicationsCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
    }
}