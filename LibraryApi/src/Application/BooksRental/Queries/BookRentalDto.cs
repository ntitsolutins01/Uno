using LibraryApi.Application.Books.Queries;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.BooksRental.Queries;

public class BookRentalDto
{
    public int Id { get; init; }
    public required BookDto Book { get; init; }
    public required string UserId { get; init; }
    public DateTime? RentalDate { get; init; }
    public DateTime? ReturnDate { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<BookRental, BookRentalDto>();
        }
    }
}
