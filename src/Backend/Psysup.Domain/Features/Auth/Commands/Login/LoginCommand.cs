﻿using MediatR;
using Psysup.DataContracts.Auth;

namespace Psysup.Domain.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<AuthResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}