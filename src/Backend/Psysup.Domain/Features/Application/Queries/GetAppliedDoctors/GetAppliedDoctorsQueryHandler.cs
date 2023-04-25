using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataContracts.Application.GetAppliedDoctors;

namespace Psysup.Domain.Features.Application.Queries.GetAppliedDoctors;

public class GetAppliedDoctorsQueryHandler : IRequestHandler<GetAppliedDoctorsQuery, GetAppliedDoctorsResponse>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAppliedDoctorsQueryHandler(IPsysupDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetAppliedDoctorsResponse> Handle(
        GetAppliedDoctorsQuery request,
        CancellationToken cancellationToken)
    {
        var doctors = await _dbContext.AppliedDoctorApplications
            .AsNoTracking()
            .Where(x => x.ApplicationId == request.ApplicationId && x.Application!.UserId == request.UserId)
            .Select(x => x.Doctor)
            .ProjectTo<GetAppliedDoctorsResponseItem>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new GetAppliedDoctorsResponse
        {
            Doctors = doctors
        };
    }
}