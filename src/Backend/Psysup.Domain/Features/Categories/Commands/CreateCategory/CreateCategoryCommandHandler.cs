using MediatR;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Data;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Categories.CreateCategory;
using Psysup.Domain.Exceptions.Categories;

namespace Psysup.Domain.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
{
    private readonly IPsysupDbContext _dbContext;

    public CreateCategoryCommandHandler(IPsysupDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await ThrowIfCategoryExistsAsync(request, cancellationToken);

        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        await _dbContext.Categories.AddAsync(category, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CreateCategoryResponse
        {
            Id = category.Id
        };
    }

    private async Task ThrowIfCategoryExistsAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(
            x => x.Name == request.Name,
            cancellationToken);

        if (category != null)
        {
            throw new CategoryAlreadyExistsException(request.Name);
        }
    }
}