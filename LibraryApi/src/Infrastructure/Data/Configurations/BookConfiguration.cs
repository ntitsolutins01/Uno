using LibraryApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Infrastructure.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(t => t.Author)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(t => t.Description)
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(t => t.Genre)
            .HasMaxLength(50)
            .IsRequired();
        builder
            .OwnsOne(b => b.Language);
    }
}
