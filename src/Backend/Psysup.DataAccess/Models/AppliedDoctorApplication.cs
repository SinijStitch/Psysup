namespace Psysup.DataAccess.Models;

public class AppliedDoctorApplication
{
    public Guid DoctorId { get; set; }
    public Guid ApplicationId { get; set; }
    public bool Approved { get; set; }
    public bool AsDoctor { get; set; }

    public User? Doctor { get; set; }
    public Application? Application { get; set; }
}