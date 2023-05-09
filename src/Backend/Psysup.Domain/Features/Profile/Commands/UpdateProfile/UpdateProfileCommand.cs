using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psysup.Domain.Features.Profile.Commands.UpdateProfile
{
    public class UpdateProfileCommand : IRequest
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public IFormFile Image { get; set; } = null!;
    }
}
