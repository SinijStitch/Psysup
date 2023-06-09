﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataContracts.Application.GetApplications;

namespace Psysup.Domain.Features.Applications.Queries.GetApplications;

public class GetApplicationsQueryHandler : IRequestHandler<GetApplicationsQuery, GetApplicationsResponse>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetApplicationsQueryHandler(IPsysupDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetApplicationsResponse> Handle(
        GetApplicationsQuery request,
        CancellationToken cancellationToken)
    {
        var query = _dbContext.Applications.AsNoTracking();

        switch (request)
        {
            case { IsApplied: true, IsPublic: true }:
                query = query.Where(x =>
                    x.UserId != request.UserId
                    && x.AppliedDoctorApplications!.Any(applied => applied.DoctorId == request.UserId));
                break;
            case { IsApplied: false, IsPublic: true }:
                query = query.Where(x =>
                    x.UserId != request.UserId &&
                    x.AppliedDoctorApplications!.All(applied => applied.DoctorId != request.UserId));
                break;
            case { IsPublic: false }:
                query = query.Where(x => x.UserId == request.UserId);
                break;
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(x => x.Title)
            .Skip(request.PageSize * request.PageNumber - request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<GetApplicationsResponseItem>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new GetApplicationsResponse
        {
            TotalCount = totalCount,
            Applications = items
        };
    }
}