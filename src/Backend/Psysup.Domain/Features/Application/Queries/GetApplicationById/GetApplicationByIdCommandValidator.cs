using FluentValidation;

namespace Psysup.Domain.Features.Application.Queries.GetApplicationById;

public class GetApplicationByIdCommandValidator : AbstractValidator<GetApplicationByIdCommand>
{
    public GetApplicationByIdCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.ApplicationId).NotEmpty();
    }
}