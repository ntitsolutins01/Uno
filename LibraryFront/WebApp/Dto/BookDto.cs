namespace WebApp.Dto
{
    public class BookDto
    {
        public required int Id { get; set; }
        public required string Title { get; init; }
        public required string Author { get; init; }
        public required string Description { get; init; }
        public required string Genre { get; init; }
        public required string Code { get; init; }
        public required string Language { get; init; }
    }
}
