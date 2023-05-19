using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Profile;

public class ProfileWasNotFoundException : NotFoundException
{
    private const string ErrorMessage = "The profile was blocked or removed.";

    public ProfileWasNotFoundException() : base(ErrorMessage)
    {
    }

    public override int Code => (int)ProfileCodes.ProfileWasNotFound;
}