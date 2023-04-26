using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Profile;

public class ProfileWasNotFoundException : NotFoundException
{
    private const string ErrorMessage = "The profile was not found.";

    public ProfileWasNotFoundException() : base(ErrorMessage)
    {
    }

    public override int Code => (int)ProfileCodes.ProfileWasNotFound;
}