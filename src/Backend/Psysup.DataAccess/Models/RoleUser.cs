namespace Psysup.DataAccess.Models;

public class RoleUser
{
    public Guid UsersId { get; set; }
    public Guid RolesId { get; set; }

    public User? User { get; set; }
    public Role? Role { get; set; }
}