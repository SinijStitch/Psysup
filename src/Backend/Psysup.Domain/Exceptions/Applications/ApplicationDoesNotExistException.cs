using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Applications;

public class ApplicationDoesNotExistException : NotFoundException
{
    private const string ErrorMessage = "Application was not found.";

    public ApplicationDoesNotExistException()
        : base(ErrorMessage)
    {
    }

    public override int Code => (int)ApplicationsCodes.ApplicationDoesNotExist;
}