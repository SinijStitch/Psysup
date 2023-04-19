using MediatR;
using Psysup.DataContracts.Application.GetApplications;

namespace Psysup.Domain.Features.Application.Queries.GetApplications;

public class GetApplicationsCommand : IRequest<GetApplicationsResponse>
{
    public Guid UserId { get; set; }
    public bool IsPublic { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}