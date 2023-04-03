using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psysup.DataAccess.Models;

namespace Psysup.DataAccess.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(100).IsRequired();

        builder.HasIndex(x => x.Email).IsUnique().IncludeProperties(x => new { x.Password });

        builder
            .HasMany(x => x.Applications)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users);
    }
}