using MediatR;
using Psysup.Domain.Services.Auth;

namespace Psysup.Domain.Features.Auth.Commands.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
{
    private readonly IAuthService _authService;

    public LogoutCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await _authService.SignOutAsync();
    }
}