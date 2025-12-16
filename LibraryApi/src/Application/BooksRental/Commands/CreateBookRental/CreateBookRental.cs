using System.Globalization;
using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Domain.Entities;
using LibraryApi.Domain.GuardClause;

namespace LibraryApi.Application.BooksRental.Commands.CreateBookRental;

public record CreateBookRentalCommand : IRequest<bool>
{
    public required string UserId { get; init; }
    public required int BookId { get; init; }
    public required string RentalDate { get; init; }
}

public class CreateBookRentalCommandHandler : IRequestHandler<CreateBookRentalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public CreateBookRentalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(CreateBookRentalCommand request, CancellationToken cancellationToken)
    {
        var book = await _context.Books
            .FindAsync(new object[] { request.BookId }, cancellationToken);

        Guard.Against.NotFound(request.BookId, book);

        var rentalDate = DateTime.ParseExact(request.RentalDate, "yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en"));

        var bookRental =
            _context.BooksRental.Any(x =>
                x.Book.Id == request.BookId && x.RentalDate <= rentalDate && x.ReturnDate == null);

        Guard.Against.BookRent(bookRental);

        var entity = new BookRental
        {
            Book = book,
            UserId = request.UserId,
            RentalDate = rentalDate
        };

        _context.BooksRental.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id >= 1;
    }
}
