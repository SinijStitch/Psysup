using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataAccess.Models;
using Psysup.Domain.Exceptions.Applications;

namespace Psysup.Domain.Features.Applications.Commands.ApplyDoctor;

public class ApplyDoctorCommandHandler : IRequestHandler<ApplyDoctorCommand>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public ApplyDoctorCommandHandler(IPsysupDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Handle(ApplyDoctorCommand request, CancellationToken cancellationToken)
    {
        await ThrowIfRecordExists(request, cancellationToken);
        await ThrowIfApplicationDoesNotExist(request, cancellationToken);

        var newRecord = _mapper.Map<AppliedDoctorApplication>(request);
        newRecord.AsDoctor = true;

        await _dbContext.AppliedDoctorApplications.AddAsync(newRecord, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ThrowIfApplicationDoesNotExist(ApplyDoctorCommand request, CancellationToken cancellationToken)
    {
        var doesApplicationExist = await _dbContext
            .Applications
            .AsNoTracking()
            .Where(x => x.Id == request.ApplicationId)
            .AnyAsync(cancellationToken);

        if (!doesApplicationExist)
        {
            throw new ApplicationDoesNotExistException();
        }
    }

    private async Task ThrowIfRecordExists(ApplyDoctorCommand request, CancellationToken cancellationToken)
    {
        var doesRecordExist = await _dbContext.AppliedDoctorApplications
            .AsNoTracking()
            .Where(x => x.DoctorId == request.DoctorId && x.ApplicationId == request.ApplicationId)
            .AnyAsync(cancellationToken);

        if (doesRecordExist)
        {
            throw new DoctorAlreadyAppliedToApplication();
        }
    }
}