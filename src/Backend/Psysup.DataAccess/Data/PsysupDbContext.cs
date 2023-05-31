using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Models;

namespace Psysup.DataAccess.Data;

public class PsysupDbContext : DbContext, IPsysupDbContext
{
    public PsysupDbContext(DbContextOptions<PsysupDbContext> options) : base(options)
    {
    }


    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<RoleUser> RoleUsers { get; set; } = null!;
    public DbSet<Application> Applications { get; set; } = null!;
    public DbSet<AppliedDoctorApplication> AppliedDoctorApplications { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<ApplicationCategory> ApplicationCategories { get; set; } = null!;
    public DbSet<Chat> Chats { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<ChatUser> ChatUsers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}