using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Auth;

public class UserAlreadyExistsException : ValidationException
{
    private const string ErrorMessage = "User with provided email '{0}' already exists.";

    public UserAlreadyExistsException(string email) : base(string.Format(ErrorMessage, email))
    {
    }

    public override int Code => (int)AuthCode.UserAlreadyExists;
}