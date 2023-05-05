using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.ValueObjects;

namespace SimpleCrud.Infrastructure.DAL.Configurations;

internal sealed class PhoneBookConfiguration : IEntityTypeConfiguration<PhoneBook>
{
    public void Configure(EntityTypeBuilder<PhoneBook> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new Id(x));
        builder.Property(x => x.PhoneNumber)
            .HasConversion(x => x.Value, x => new PhoneNumber(x));
        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => new Name(x));
    }
}   