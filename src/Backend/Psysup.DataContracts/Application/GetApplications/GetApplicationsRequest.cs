namespace Psysup.DataContracts.Application.GetApplications;

public class GetApplicationsRequest : PageRequest
{
    public bool IsPublic { get; set; }
}