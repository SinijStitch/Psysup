namespace Psysup.DataContracts.Users.ChangeUserRoles;

public class ChangeUserRolesRequest
{
    public IEnumerable<string> Roles { get; set; } = new List<string>();
}