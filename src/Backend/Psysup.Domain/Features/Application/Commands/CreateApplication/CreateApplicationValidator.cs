using FluentValidation;

namespace Psysup.Domain.Features.Application.Commands.CreateApplication;

public class CreateApplicationValidator : AbstractValidator<CreateApplicationCommand>
{
    public CreateApplicationValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
        RuleFor(x => x.Price).GreaterThanOrEqualTo(1);
        RuleFor(x => x.Categories).NotEmpty();
        RuleFor(x => x.Categories).Must(IsCategoriesHasDuplication).WithMessage("Categories have duplications.");
    }

    private static bool IsCategoriesHasDuplication(IEnumerable<string> categories)
    {
        var categoriesList = categories.ToList();
        return categoriesList.Count == categoriesList.Distinct().Count();
    }
}