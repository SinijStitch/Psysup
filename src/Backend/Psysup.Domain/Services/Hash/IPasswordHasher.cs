namespace Psysup.Domain.Services.Hash;

public interface IPasswordHasher
{
    string HasPassword(string password);
    bool Verify(string password, string hash);
}