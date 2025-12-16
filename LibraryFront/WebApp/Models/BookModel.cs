using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Dto;

namespace WebApp.Models
{
    public class BookModel
    {
        public BookDto Book { get; set; }
        public List<BookDto> Books { get; set; }
        public string BookId { get; set; }
        public SelectList ListBooks { get; set; }
        public string GenreId { get; set; }
        public SelectList ListGenre { get; set; }
        public string LanguageId { get; set; }
        public SelectList ListLanguage { get; set; }
        public BooksFilterDto SearchFilter { get; set; }

        public class CreateUpdateBookCommand
        {
            public int Id { get; set; }
            public required string Title { get; init; }
            public required string Author { get; init; }
            public required string Description { get; init; }
            public required string Genre { get; init; }
            public required string Language { get; init; }
            public DateTime? RentDate { get; set; }
        }
        public class CreateBookRentalCommand
        {
            public required string UserId { get; init; }
            public required int BookId { get; init; }
            public string? RentalDate { get; init; }
        }
    }

}