using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataContracts.Categories.GetCategories;

namespace Psysup.Domain.Features.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, GetCategoriesResponse>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(IPsysupDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetCategoriesResponse> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _dbContext.Categories
            .AsNoTracking()
            .ProjectTo<GetCategoriesResponseItem>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new GetCategoriesResponse
        {
            Categories = categories
        };
    }
}