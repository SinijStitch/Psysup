using FluentValidation;

namespace Psysup.Domain.Features.Applications.Commands.ApplyDoctor;

public class ApplyDoctorCommandValidator : AbstractValidator<ApplyDoctorCommand>
{
    public ApplyDoctorCommandValidator()
    {
        RuleFor(x => x.DoctorId).NotEmpty();
        RuleFor(x => x.ApplicationId).NotEmpty();
    }
}