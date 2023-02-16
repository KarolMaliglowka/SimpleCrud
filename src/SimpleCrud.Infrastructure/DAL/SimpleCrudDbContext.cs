using Microsoft.EntityFrameworkCore;

namespace SimpleCrud.Infrastructure.DAL;

internal sealed class SimpleCrudDbContext : DbContext
{
    // public DbSet<PhoneBook> PhonesBook { get; set; }

    public SimpleCrudDbContext(DbContextOptions<SimpleCrudDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
}