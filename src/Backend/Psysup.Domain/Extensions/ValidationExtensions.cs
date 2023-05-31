using FluentValidation;

namespace Psysup.Domain.Extensions;

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.NotEmpty().MinimumLength(2);
    }

    public static IRuleBuilderOptions<T, string> ChatMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.NotEmpty().MaximumLength(300);
    }
}