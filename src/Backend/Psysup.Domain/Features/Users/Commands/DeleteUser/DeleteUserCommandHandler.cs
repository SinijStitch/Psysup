using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataAccess.Models;
using Psysup.Domain.Enums;
using Psysup.Domain.Exceptions.Users;

namespace Psysup.Domain.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IPsysupDbContext _dbContext;

    public DeleteUserCommandHandler(IPsysupDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Where(x => x.Id == request.Id)
            .Select(x => new User
            {
                Id = x.Id,
                Roles = x.Roles!.ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            throw new UserWasNotFoundException();
        }

        if (user.Roles!.Any(x => x.Name == Roles.Admin.ToString()))
        {
            throw new CannotRemoveAdminException();
        }

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}