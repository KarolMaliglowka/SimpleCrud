using Microsoft.EntityFrameworkCore;
using SimpleCrud.Core.Entities;

namespace SimpleCrud.Infrastructure.DAL;

public class SimpleCrudDbContext : DbContext
{
    public DbSet<PhoneBook> PhonesBooks { get; set; }

    public SimpleCrudDbContext(DbContextOptions<SimpleCrudDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}