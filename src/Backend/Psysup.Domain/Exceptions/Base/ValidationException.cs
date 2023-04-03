using System.Net;

namespace Psysup.Domain.Exceptions.Base;

public abstract class ValidationException : RestException
{
    protected ValidationException(string message) : base(message)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public override string Description => "A validation error occurred while passing invalid data.";
}