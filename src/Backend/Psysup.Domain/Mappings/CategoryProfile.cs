using AutoMapper;
using Psysup.DataContracts.Categories.CreateCategory;
using Psysup.Domain.Features.Category.Commands.CreateCategory;

namespace Psysup.Domain.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryRequest, CreateCategoryCommand>();
    }
}