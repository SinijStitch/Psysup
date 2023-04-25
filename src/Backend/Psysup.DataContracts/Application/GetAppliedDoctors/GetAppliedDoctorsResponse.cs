namespace Psysup.DataContracts.Application.GetAppliedDoctors;

public class GetAppliedDoctorsResponse
{
    public IEnumerable<GetAppliedDoctorsResponseItem> Doctors { get; set; } =
        new List<GetAppliedDoctorsResponseItem>();
}