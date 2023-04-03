using System.Net;
using Psysup.Domain.Exceptions.Base;

namespace Psysup.Domain.Exceptions.Common;

public class NonGeneralException : RestException
{
    public NonGeneralException(string message) : base(message)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
    public override int Code => (int)CommonCode.NonGeneralErrorOccurred;

    public override string Description =>
        "A non-general error has occurred that should not be in the correct workflow.";
}