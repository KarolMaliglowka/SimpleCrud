using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCrud.Core.Entities;

namespace SimpleCrud.Infrastructure.DAL.Configurations;

internal sealed class PhoneBookConfiguration : IEntityTypeConfiguration<PhoneBook>
{
    public void Configure(EntityTypeBuilder<PhoneBook> builder)
    {
        builder.Property(x => x.Id);
        builder.Property(x => x.PhoneNumber);
        builder.Property(x => x.FirstName);
        builder.Property(x => x.LastName);
    }
}