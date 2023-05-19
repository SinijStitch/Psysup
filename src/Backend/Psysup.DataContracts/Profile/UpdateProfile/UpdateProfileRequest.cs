using Microsoft.AspNetCore.Http;

namespace Psysup.DataContracts.Profile.UpdateProfile;

public class UpdateProfileRequest
{
    public string? Email { get; set; }
    public string? NewPassword { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public IFormFile? Image { get; set; }
}