using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Applications;

public class OneOrMoreCategoryDoesNotExist : ValidationException
{
    private const string ErrorMessage = "One or more categories does not exist. Invalid Categories: '{0}'";

    public OneOrMoreCategoryDoesNotExist(IEnumerable<string> categories)
        : base(string.Format(ErrorMessage, string.Join(", ", categories)))
    {
    }

    public override int Code => (int)ApplicationsCodes.OneOrMoreCategoryDoesNotExist;
}