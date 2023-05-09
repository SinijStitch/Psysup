namespace Psysup.DataContracts.Profile.GetProfile;

public class GetProfileResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? ImagePath { get; set; }
    public IEnumerable<string> Roles { get; set; } = new List<string>();
}