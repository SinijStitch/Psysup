using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psysup.DataAccess.Models;

namespace Psysup.DataAccess.EntityTypeConfigurations;

public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();

        builder
            .HasMany(x => x.Users)
            .WithMany(x => x.Roles)
            .UsingEntity<RoleUser>();

        builder.HasData(new List<Role>
        {
            new()
            {
                Id = Guid.Parse("86A8803F-569D-4F6E-9433-7DFCCBF79EC2"),
                Name = "Admin"
            },
            new()
            {
                Id = Guid.Parse("05AAB560-B9C7-4458-9642-2BA1A3A83237"),
                Name = "User"
            },
            new()
            {
                Id = Guid.Parse("28CD0A64-9C83-45D9-8FC3-BD7883FB7376"),
                Name = "Doctor"
            }
        });
    }
}