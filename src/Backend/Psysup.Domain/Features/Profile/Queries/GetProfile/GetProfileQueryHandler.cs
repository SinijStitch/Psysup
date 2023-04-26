using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataContracts.Profile.GetProfile;
using Psysup.Domain.Exceptions.Profile;

namespace Psysup.Domain.Features.Profile.Queries.GetProfile;

public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileResponse>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProfileQueryHandler(IPsysupDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var profileResponse = await _dbContext.Users
            .AsNoTracking()
            .Include(x => x.Roles)
            .Where(x => x.Id == request.UserId)
            .ProjectTo<GetProfileResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return profileResponse ?? throw new ProfileWasNotFoundException();
    }
}