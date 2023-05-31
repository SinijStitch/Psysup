using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataContracts.Application.GetApplicationById;
using Psysup.Domain.Exceptions.Applications;

namespace Psysup.Domain.Features.Applications.Queries.GetApplicationById;

public class GetApplicationByIdQueryHandler : IRequestHandler<GetApplicationByIdQuery, GetApplicationByIdResponse>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetApplicationByIdQueryHandler(IPsysupDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetApplicationByIdResponse> Handle(
        GetApplicationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _dbContext.Applications
            .AsNoTracking()
            .Include(x => x.Categories)
            .Where(x => x.Id == request.ApplicationId && x.UserId == request.UserId)
            .ProjectTo<GetApplicationByIdResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return response ?? throw new ApplicationDoesNotExistException();
    }
}