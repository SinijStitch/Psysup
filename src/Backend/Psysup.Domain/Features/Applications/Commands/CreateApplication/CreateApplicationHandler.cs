using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Application.CreateApplication;
using Psysup.Domain.Exceptions.Applications;

namespace Psysup.Domain.Features.Applications.Commands.CreateApplication;

public class CreateApplicationHandler : IRequestHandler<CreateApplicationCommand, CreateApplicationResponse>
{
    private readonly IPsysupDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateApplicationHandler(IPsysupDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CreateApplicationResponse> Handle(
        CreateApplicationCommand request,
        CancellationToken cancellationToken)
    {
        var categories = await _dbContext.Categories
            .AsNoTracking()
            .Where(x => request.Categories.Contains(x.Name))
            .ToListAsync(cancellationToken);

        if (categories.Count != request.Categories.Count())
        {
            var invalidCategories = request.Categories.Except(categories.Select(x => x.Name));
            throw new OneOrMoreCategoryDoesNotExist(invalidCategories);
        }

        var application = _mapper.Map<Application>(request);

        var applicationCategories = categories
            .Select(category => new ApplicationCategory
            {
                ApplicationId = application.Id,
                CategoryId = category.Id
            });

        await _dbContext.Applications.AddAsync(application, cancellationToken);
        await _dbContext.ApplicationCategories.AddRangeAsync(applicationCategories, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CreateApplicationResponse
        {
            Id = application.Id
        };
    }
}