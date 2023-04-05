namespace Psysup.Domain.Services.Hash;

public class PasswordHasher : IPasswordHasher
{
    public string HasPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}