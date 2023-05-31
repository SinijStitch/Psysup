using MediatR;
using Psysup.DataContracts.Application.GetApplications;
using Psysup.Domain.Enums;

namespace Psysup.Domain.Features.Applications.Queries.GetApplications;

public class GetApplicationsQuery : PageQuery, IRequest<GetApplicationsResponse>
{
    public Guid UserId { get; set; }
    public Roles Roles { get; set; }
    public bool IsPublic { get; set; }
    public bool IsApplied { get; set; }
}