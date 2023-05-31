using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataAccess.Models;
using Psysup.Domain.Enums;
using Psysup.Domain.Exceptions.Applications;

namespace Psysup.Domain.Features.Applications.Commands.DeleteApplication;

public class DeleteApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand>
{
    private readonly IPsysupDbContext _dbContext;

    public DeleteApplicationCommandHandler(IPsysupDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
    {
        var application = await _dbContext.Applications
            .Where(x => x.Id == request.ApplicationId)
            .Select(x => new Application
            {
                Id = x.Id,
                UserId = x.UserId
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (application == null || (!request.Roles.HasFlag(Roles.Admin) && request.UserId != application.UserId))
        {
            throw new ApplicationDoesNotExistException();
        }

        var hasDoctor = await _dbContext.AppliedDoctorApplications
            .AnyAsync(x => x.ApplicationId == request.ApplicationId, cancellationToken);

        if (hasDoctor)
        {
            throw new DoctorAlreadyAppliedToApplication();
        }

        _dbContext.Applications.Remove(application);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}