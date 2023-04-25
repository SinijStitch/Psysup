using MediatR;

namespace Psysup.Domain.Features.Application.Commands.ApplyDoctor;

public class ApplyDoctorCommand : IRequest
{
    public Guid DoctorId { get; set; }
    public Guid ApplicationId { get; set; }
}