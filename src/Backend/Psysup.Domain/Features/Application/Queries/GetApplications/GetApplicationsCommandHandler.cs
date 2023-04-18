using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataContracts.Application.GetApplications;

namespace Psysup.Domain.Features.Application.Queries.GetApplications;

public class GetApplicationsCommandHandler : IRequestHandler<GetApplicationsCommand, GetApplicationsResponse>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetApplicationsCommandHandler(IPsysupDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetApplicationsResponse> Handle(
        GetApplicationsCommand request,
        CancellationToken cancellationToken)
    {
        var items = await _dbContext.Applications
            .Where(x => x.UserId == request.UserId)
            .OrderBy(x => x.Title)
            .Skip(request.PageSize * request.PageNumber - request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<GetApplicationsResponseItem>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new GetApplicationsResponse
        {
            Applications = items
        };
    }
}