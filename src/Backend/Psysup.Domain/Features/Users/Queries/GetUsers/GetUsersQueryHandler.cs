using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataContracts.Users.GetUsers;

namespace Psysup.Domain.Features.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersResponse>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IPsysupDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetUsersResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Users
            .AsNoTracking()
            .Where(x => x.Id != request.UserId);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(x => x.Email)
            .Skip(request.PageSize * request.PageNumber - request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<GetUsersResponseItem>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new GetUsersResponse
        {
            TotalCount = totalCount,
            Users = items
        };
    }
}