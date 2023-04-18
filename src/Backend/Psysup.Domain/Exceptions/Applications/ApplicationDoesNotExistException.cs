using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Applications;

public class ApplicationDoesNotExistException : NotFoundException
{
    private const string ErrorMessage = "Application was not found. Application ID: '{0}'";

    public ApplicationDoesNotExistException(Guid id)
        : base(string.Format(ErrorMessage, id))
    {
    }

    public override int Code => (int)ApplicationsCodes.ApplicationDoesNotExist;
}