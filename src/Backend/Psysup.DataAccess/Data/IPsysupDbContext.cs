using Microsoft.EntityFrameworkCore;
using Psysup.DataAccess.Models;

namespace Psysup.DataAccess.Data;

public interface IPsysupDbContext : IDisposable, IAsyncDisposable
{
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<Application> Applications { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}