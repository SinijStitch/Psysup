using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Users;

public class CannotRemoveAdminException : ValidationException
{
    private const string ErrorMessage = "Does not have permissions to delete an administrator.";

    public CannotRemoveAdminException() : base(ErrorMessage)
    {
    }

    public override int Code => (int)UsersCodes.CannotRemoveAdmin;
}