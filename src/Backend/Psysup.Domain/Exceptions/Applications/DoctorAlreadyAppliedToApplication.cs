using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Applications;

public class DoctorAlreadyAppliedToApplication : ValidationException
{
    private const string ErrorMessage = "The doctor is already applied to the provided application.";

    public DoctorAlreadyAppliedToApplication()
        : base(ErrorMessage)
    {
    }

    public override int Code => (int)ApplicationsCodes.DoctorAlreadyAppliedToApplication;
}