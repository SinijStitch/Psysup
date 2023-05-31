using MediatR;
using Psysup.DataContracts.Application.GetApplicationById;

namespace Psysup.Domain.Features.Applications.Queries.GetApplicationById;

public class GetApplicationByIdQuery : IRequest<GetApplicationByIdResponse>
{
    public Guid UserId { get; set; }
    public Guid ApplicationId { get; set; }
}