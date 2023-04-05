using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.EntityTypeConfigurations;
using Psysup.DataAccess.Models;

namespace Psysup.DataAccess.Data;

public class PsysupDbContext : DbContext, IPsysupDbContext
{
    public PsysupDbContext(DbContextOptions<PsysupDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Application> Applications { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ApplicationEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RoleEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
    }
}