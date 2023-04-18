using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Categories;

public class CategoryAlreadyExistsException : ValidationException
{
    private const string ErrorMessage = "Category already exists. Category Name: '{0}'";

    public CategoryAlreadyExistsException(string name)
        : base(string.Format(ErrorMessage, name))
    {
    }

    public override int Code => (int)CategoriesCodes.CategoryAlreadyExists;
}