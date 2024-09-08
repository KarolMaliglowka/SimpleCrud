using Microsoft.EntityFrameworkCore;
using SimpleCrud.Core.Entities;

namespace SimpleCrud.Infrastructure.DAL;

public class SimpleCrudDbContext(DbContextOptions<SimpleCrudDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<PhoneBook> PhonesBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}