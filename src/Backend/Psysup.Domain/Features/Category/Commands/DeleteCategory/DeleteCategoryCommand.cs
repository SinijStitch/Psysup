using MediatR;

namespace Psysup.Domain.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest
{
    public Guid Id { get; set; }
}