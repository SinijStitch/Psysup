using System.Net;

namespace Psysup.Domain.Exceptions.Base;

public abstract class NotFoundException : RestException
{
    protected NotFoundException(string message) : base(message)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public override string Description => "The request data was not found";
}