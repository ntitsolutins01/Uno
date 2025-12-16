using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Book> Books { get; }
    DbSet<BookRental> BooksRental { get; }
    DbSet<Genre> Genres { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
