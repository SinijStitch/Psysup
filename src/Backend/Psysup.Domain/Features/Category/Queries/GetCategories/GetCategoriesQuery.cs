using MediatR;
using Psysup.DataContracts.Categories.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psysup.Domain.Features.Category.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<GetCategoriesResponse>
    {
    }
}
