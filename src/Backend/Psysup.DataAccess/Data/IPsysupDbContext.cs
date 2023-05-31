using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Models;

namespace Psysup.DataAccess.Data;

public interface IPsysupDbContext : IDisposable, IAsyncDisposable
{
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<RoleUser> RoleUsers { get; }
    DbSet<Application> Applications { get; }
    DbSet<AppliedDoctorApplication> AppliedDoctorApplications { get; }
    DbSet<Category> Categories { get; }
    DbSet<ApplicationCategory> ApplicationCategories { get; }
    DbSet<Chat> Chats { get; }
    DbSet<Message> Messages { get; }
    DbSet<ChatUser> ChatUsers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}