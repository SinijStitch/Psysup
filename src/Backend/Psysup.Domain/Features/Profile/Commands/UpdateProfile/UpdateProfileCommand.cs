using MediatR;
using Microsoft.AspNetCore.Http;

namespace Psysup.Domain.Features.Profile.Commands.UpdateProfile;

public class UpdateProfileCommand : IRequest
{
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? NewPassword { get; set; }
    public IFormFile? Image { get; set; }
}