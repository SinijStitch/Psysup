using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psysup.DataAccess.Models;

namespace Psysup.DataAccess.EntityTypeConfigurations;

public class AppliedDoctorApplicationEntityTypeConfiguration : IEntityTypeConfiguration<AppliedDoctorApplication>
{
    public void Configure(EntityTypeBuilder<AppliedDoctorApplication> builder)
    {
        builder.HasKey(x => new { x.DoctorId, x.ApplicationId });
        builder.Property(x => x.Approved).IsRequired().HasDefaultValue(false);
        builder.Property(x => x.AsDoctor).IsRequired().HasDefaultValue(false);

        builder
            .HasOne(x => x.Doctor)
            .WithMany(x => x.DoctorApplications)
            .HasForeignKey(x => x.DoctorId);

        builder
            .HasOne(x => x.Application)
            .WithMany(x => x.AppliedDoctorApplications)
            .HasForeignKey(x => x.ApplicationId);
    }
}