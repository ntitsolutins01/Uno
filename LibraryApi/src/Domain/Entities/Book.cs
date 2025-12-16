namespace LibraryApi.Domain.Entities;

public class Book : BaseAuditableEntity
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Description { get; set; }
    public required string Genre { get; set; }
    public Language Language { get; set; } = Language.English;
}
