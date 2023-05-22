using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Users;

public class CannotChangeAdminRolesException : ValidationException
{
    private const string ErrorMessage = "Does not have permissions to change roles of the administrator.";

    public CannotChangeAdminRolesException() : base(ErrorMessage)
    {
    }

    public override int Code => (int)UsersCodes.CannotChangeAdminRoles;
}