using Microsoft.AspNetCore.Http;

namespace Psysup.DataContracts.Profile.UpdateProfile;

public class UpdateProfileRequest
{
    public string? Email { get; set; }
    public string? NewPassword { get; set; }
    public IFormFile? Image { get; set; }
}