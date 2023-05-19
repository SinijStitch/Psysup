using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataContracts.Profile.GetProfile;
using Psysup.Domain.Exceptions.Profile;
using Psysup.Domain.Services.Auth;

namespace Psysup.Domain.Features.Profile.Queries.GetProfile;

public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileResponse>
{
    private readonly IAuthService _authService;
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProfileQueryHandler(IPsysupDbContext dbContext, IMapper mapper, IAuthService authService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<GetProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var profileResponse = await _dbContext.Users
            .AsNoTracking()
            .Include(x => x.Roles)
            .Where(x => x.Id == request.UserId)
            .ProjectTo<GetProfileResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (profileResponse == null)
        {
            await _authService.SignOutAsync();
            throw new ProfileWasNotFoundException();
        }

        return profileResponse;
    }
}