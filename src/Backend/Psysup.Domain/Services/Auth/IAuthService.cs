using Psysup.DataAccess.Models;

namespace Psysup.Domain.Services.Auth;

public interface IAuthService
{
    Task SignInAsync(User user);
    Task SignOutAsync();
}