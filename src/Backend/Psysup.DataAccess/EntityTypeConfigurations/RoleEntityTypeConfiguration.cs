using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psysup.DataAccess.Models;

namespace Psysup.DataAccess.EntityTypeConfigurations
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder
               .HasMany(x => x.Users)
               .WithMany(x => x.Roles);
        }
    }
}
