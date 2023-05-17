using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Applications;

public class UnableDeleteApplicationWithAppliedDoctorException : ValidationException
{
    private const string ErrorMessage = "Cannot delete the appliction because it has the applied doctor";

    public UnableDeleteApplicationWithAppliedDoctorException(string message) : base(ErrorMessage)
    {
    }

    public override int Code => (int)ApplicationsCodes.DoctorAlreadyAppliedToApplication;
}