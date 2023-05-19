using MediatR;
using Psysup.DataContracts.Auth;

namespace Psysup.Domain.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<AuthResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}