using MediatR;
using Psysup.DataContracts.Profile.GetProfile;

namespace Psysup.Domain.Features.Profile.Queries.GetProfile;

public class GetProfileQuery : IRequest<GetProfileResponse>
{
    public Guid UserId { get; set; }
}