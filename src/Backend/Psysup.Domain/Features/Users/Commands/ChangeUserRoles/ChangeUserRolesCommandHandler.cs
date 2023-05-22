using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataAccess.Models;
using Psysup.Domain.Enums;
using Psysup.Domain.Exceptions.Users;

namespace Psysup.Domain.Features.Users.Commands.ChangeUserRoles;

public class ChangeUserRolesCommandHandler : IRequestHandler<ChangeUserRolesCommand>
{
    private readonly IPsysupDbContext _dbContext;

    public ChangeUserRolesCommandHandler(IPsysupDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(ChangeUserRolesCommand request, CancellationToken cancellationToken)
    {
        var roleUsers = await _dbContext.RoleUsers
            .Include(x => x.User)
            .Include(x => x.Role)
            .Where(x => x.UserId == request.Id)
            .ToListAsync(cancellationToken);

        if (roleUsers.Count == 0)
        {
            throw new UserWasNotFoundException();
        }

        if (roleUsers.Any(x => x.Role!.Name == Roles.Admin.ToString()))
        {
            throw new CannotChangeAdminRolesException();
        }

        var newRoles = await _dbContext.Roles
            .Where(x => request.Roles.Contains(x.Name))
            .ToListAsync(cancellationToken);

        _dbContext.RoleUsers.RemoveRange(roleUsers);
        await _dbContext.RoleUsers.AddRangeAsync(newRoles.Select(newRole => new RoleUser
        {
            UserId = request.Id,
            RoleId = newRole.Id
        }), cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}