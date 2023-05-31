using AutoMapper;
using Psysup.DataAccess.Models;
using Psysup.DataContracts.Categories.CreateCategory;
using Psysup.DataContracts.Categories.GetCategories;
using Psysup.Domain.Features.Categories.Commands.CreateCategory;

namespace Psysup.Domain.Mappings;

public class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<CreateCategoryRequest, CreateCategoryCommand>();
        CreateMap<Category, GetCategoriesResponseItem>();
    }
}