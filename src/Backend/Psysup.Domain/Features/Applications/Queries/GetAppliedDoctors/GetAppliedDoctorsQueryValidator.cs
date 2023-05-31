using FluentValidation;

namespace Psysup.Domain.Features.Applications.Queries.GetAppliedDoctors;

public class GetAppliedDoctorsQueryValidator : AbstractValidator<GetAppliedDoctorsQuery>
{
    public GetAppliedDoctorsQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.ApplicationId).NotEmpty();
    }
}