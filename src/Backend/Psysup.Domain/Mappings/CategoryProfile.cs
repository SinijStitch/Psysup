using AutoMapper;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Categories.CreateCategory;
using Psysup.DataContracts.Categories.GetCategories;
using Psysup.Domain.Features.Category.Commands.CreateCategory;

namespace Psysup.Domain.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryRequest, CreateCategoryCommand>();
        CreateMap<Category, GetCategoriesResponseItem>();
    }
}