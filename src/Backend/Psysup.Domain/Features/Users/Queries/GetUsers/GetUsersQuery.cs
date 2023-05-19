using MediatR;
using Psysup.DataContracts.Users.GetUsers;

namespace Psysup.Domain.Features.Users.Queries.GetUsers;

public class GetUsersQuery : PageQuery, IRequest<GetUsersResponse>
{
    public Guid UserId { get; set; }
}