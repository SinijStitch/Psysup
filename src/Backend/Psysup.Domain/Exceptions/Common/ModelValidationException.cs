using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Common;

internal class ModelValidationException : ValidationException
{
    public ModelValidationException(string message) : base(message)
    {
    }

    public override int Code => (int)CommonCode.ModelValidationFailed;
}