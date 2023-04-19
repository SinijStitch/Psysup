namespace Psysup.DataContracts.Application.GetApplications;

public class GetApplicationsResponse
{
    public int TotalCount { get; set; }

    public IEnumerable<GetApplicationsResponseItem> Applications { get; set; } =
        new List<GetApplicationsResponseItem>();
}