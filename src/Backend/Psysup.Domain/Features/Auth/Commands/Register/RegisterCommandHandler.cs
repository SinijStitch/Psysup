using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Auth;
using Psysup.Domain.Enums;
using Psysup.Domain.Exceptions.Auth;
using Psysup.Domain.Services.Auth;
using Psysup.Domain.Services.Hash;

namespace Psysup.Domain.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponse>
{
    private readonly IAuthService _authService;
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(
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

    public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await ThrowIfUserExists(request, cancellationToken);

        var newUser = await CreateANewUser(request, cancellationToken);

        await _authService.SignInAsync(newUser);

        return _mapper.Map<AuthResponse>(newUser);
    }

    private async Task<User> CreateANewUser(RegisterCommand request, CancellationToken cancellationToken)
    {
        var role = await _dbContext.Roles
            .AsNoTracking()
            .Where(x => x.Name == Roles.User.ToString())
            .FirstAsync(cancellationToken);

        var newUser = _mapper.Map<User>(request);

        newUser.PasswordHash = _passwordHasher.HasPassword(request.Password);

        var roleUser = new RoleUser { UserId = newUser.Id, RoleId = role.Id };

        await _dbContext.Users.AddAsync(newUser, cancellationToken);
        await _dbContext.RoleUsers.AddAsync(roleUser, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        newUser.Roles = new List<Role> { role };

        return newUser;
    }

    private async Task ThrowIfUserExists(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext
            .Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

        if (user != null)
        {
            throw new UserAlreadyExistsException(request.Email);
        }
    }
}