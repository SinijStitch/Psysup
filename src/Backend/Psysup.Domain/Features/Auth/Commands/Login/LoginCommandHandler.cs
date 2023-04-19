using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataContracts.Auth;
using Psysup.Domain.Exceptions.Auth;
using Psysup.Domain.Services.Auth;
using Psysup.Domain.Services.Hash;

namespace Psysup.Domain.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
{
    private readonly IAuthService _authService;
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public LoginCommandHandler(
        IPsysupDbContext dbContext,
        IAuthService authService,
        IMapper mapper,
        IPasswordHasher passwordHasher)
    {
        _dbContext = dbContext;
        _authService = authService;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

        if (user == null || !_passwordHasher.Verify(request.Password, user.PasswordHash))
        {
            throw new IncorrectEmailOrPasswordException();
        }

        await _authService.SignInAsync(user);

        return _mapper.Map<AuthResponse>(user);
    }
}