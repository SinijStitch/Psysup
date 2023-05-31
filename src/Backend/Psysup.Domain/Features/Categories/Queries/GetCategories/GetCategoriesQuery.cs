using MediatR;
using Psysup.DataContracts.Categories.GetCategories;

namespace Psysup.Domain.Features.Categories.Queries.GetCategories;

public class GetCategoriesQuery : IRequest<GetCategoriesResponse>
{
}