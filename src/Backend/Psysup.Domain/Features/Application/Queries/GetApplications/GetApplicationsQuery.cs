using MediatR;
using Psysup.DataContracts.Application.GetApplications;
using Psysup.Domain.Enums;

namespace Psysup.Domain.Features.Application.Queries.GetApplications;

public class GetApplicationsQuery : IRequest<GetApplicationsResponse>
{
    public Guid UserId { get; set; }
    public Roles Roles { get; set; }
    public bool IsPublic { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}