using MediatR;
using Psysup.DataContracts.Categories.CreateCategory;

namespace Psysup.Domain.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CreateCategoryResponse>
{
    public string Name { get; set; } = string.Empty;
}