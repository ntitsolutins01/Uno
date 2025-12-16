using LibraryApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Infrastructure.Data.Configurations;

public class BookRentalConfiguration : IEntityTypeConfiguration<BookRental>
{
    public void Configure(EntityTypeBuilder<BookRental> builder)
    {
        builder.Property(t => t.UserId)
            .HasMaxLength(450)
            .IsRequired();
    }
}
