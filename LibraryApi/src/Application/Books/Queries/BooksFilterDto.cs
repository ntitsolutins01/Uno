namespace LibraryApi.Application.Books.Queries;
public class BooksFilterDto
{
    public string? Genre { get; set; }
    public string? Code { get; set; }
    public List<BookDto>? Books { get; set; }
}
