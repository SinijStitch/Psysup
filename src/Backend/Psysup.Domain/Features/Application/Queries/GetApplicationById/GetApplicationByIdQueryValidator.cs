using FluentValidation;

namespace Psysup.Domain.Features.Application.Queries.GetApplicationById;

public class GetApplicationByIdQueryValidator : AbstractValidator<GetApplicationByIdQuery>
{
    public GetApplicationByIdQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.ApplicationId).NotEmpty();
    }
}