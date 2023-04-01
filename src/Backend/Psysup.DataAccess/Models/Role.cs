namespace Psysup.DataAccess.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public IEnumerable<User>? Users { get; set; }
    }
}
