using System.Net;

namespace Psysup.Domain.Exceptions.Base;

public abstract class RestException : Exception
{
    protected RestException(string message) : base(message)
    {
    }

    public abstract HttpStatusCode StatusCode { get; }
    public abstract int Code { get; }
    public abstract string Description { get; }
}