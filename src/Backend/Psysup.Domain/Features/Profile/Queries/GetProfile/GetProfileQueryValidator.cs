using FluentValidation;

namespace Psysup.Domain.Features.Profile.Queries.GetProfile;

public class GetProfileQueryValidator : AbstractValidator<GetProfileQuery>
{
    public GetProfileQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}