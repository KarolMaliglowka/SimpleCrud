using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCrud.Core.Entities;

namespace SimpleCrud.Infrastructure.DAL.Configurations;

internal sealed class PhoneBookConfiguration : IEntityTypeConfiguration<PhoneBook>
{
    public void Configure(EntityTypeBuilder<PhoneBook> builder)
    {
        builder.
    }
}