using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataContracts.Application.GetApplicationById;
using Psysup.Domain.Exceptions.Applications;

namespace Psysup.Domain.Features.Application.Queries.GetApplicationById;

public class GetApplicationByIdCommandHandler : IRequestHandler<GetApplicationByIdCommand, GetApplicationByIdResponse>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetApplicationByIdCommandHandler(IPsysupDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetApplicationByIdResponse> Handle(
        GetApplicationByIdCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _dbContext.Applications
            .Include(x => x.Categories)
            .Where(x => x.Id == request.ApplicationId && x.UserId == request.UserId)
            .ProjectTo<GetApplicationByIdResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return response ?? throw new ApplicationDoesNotExistException(request.ApplicationId);
    }
}