using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Users;

internal class UserWasNotFoundException : NotFoundException
{
    private const string ErrorMessage = "User was not found.";

    public UserWasNotFoundException() : base(ErrorMessage)
    {
    }

    public override int Code => (int)UsersCodes.UserWasNotFound;
}