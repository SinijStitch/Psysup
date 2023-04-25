using MediatR;
using Psysup.DataContracts.Application.GetAppliedDoctors;

namespace Psysup.Domain.Features.Application.Queries.GetAppliedDoctors;

public class GetAppliedDoctorsQuery : IRequest<GetAppliedDoctorsResponse>
{
    public Guid UserId { get; set; }
    public Guid ApplicationId { get; set; }
}