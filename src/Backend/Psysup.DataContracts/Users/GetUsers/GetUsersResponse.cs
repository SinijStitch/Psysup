namespace Psysup.DataContracts.Users.GetUsers;

public class GetUsersResponse
{
    public int TotalCount { get; set; }
    public IEnumerable<GetUsersResponseItem> Users { get; set; } = new List<GetUsersResponseItem>();
}