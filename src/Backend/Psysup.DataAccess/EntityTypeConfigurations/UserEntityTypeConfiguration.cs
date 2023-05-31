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
        builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.PasswordHash).HasMaxLength(100).IsRequired();
        builder.Property(x => x.ImagePath).HasMaxLength(100);

        builder.HasIndex(x => x.Email).IsUnique()
            .IncludeProperties(x => new { Password = x.PasswordHash, x.ImagePath });

        builder
            .HasMany(x => x.Applications)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<RoleUser>();

        builder
            .HasMany(x => x.Chats)
            .WithMany(x => x.Users)
            .UsingEntity<ChatUser>();

        builder.HasData(new User
        {
            Id = Guid.Parse("FDA48C05-48B8-4655-B1E5-F0D707568EE3"),
            Email = "psysadmin@gmail.com",
            PasswordHash = "$2b$10$u9qwtAmulUGnGH3fWiH3/ujpTuQYbOcJUj0EDvd/xYW8nueUjwdAK"
        });
    }
}