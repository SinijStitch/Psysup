namespace Psysup.DataContracts.Application.GetApplications;

public class GetApplicationsRequest
{
    public bool IsPublic { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}