namespace Psysup.DataContracts.Application.GetApplications;

public class GetApplicationsResponse
{
    public IEnumerable<GetApplicationsResponseItem> Applications { get; set; } =
        new List<GetApplicationsResponseItem>();
}