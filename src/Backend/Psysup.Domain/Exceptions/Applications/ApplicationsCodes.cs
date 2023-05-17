namespace Psysup.Domain.Exceptions.Applications;

public enum ApplicationsCodes
{
    ApplicationDoesNotExist = 4000,
    OneOrMoreCategoryDoesNotExist = 4001,
    DoctorAlreadyAppliedToApplication = 4002,
    UnableDeleteApplicationWithAppliedDoctor = 4003
}