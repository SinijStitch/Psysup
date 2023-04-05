using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Auth;

public class IncorrectEmailOrPasswordException : ValidationException
{
    private const string ErrorMessage = "Provided invalid email or password.";

    public IncorrectEmailOrPasswordException() : base(ErrorMessage)
    {
    }

    public override int Code => (int)AuthCode.IncorrectEmailOrPassword;
}