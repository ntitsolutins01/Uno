using LibraryApi.Domain.Entities;
using LibraryApi.Domain.ValueObjects;

namespace LibraryApi.Application.Books.Queries;

public class BookDto
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required string Author { get; init; }
    public required string Description { get; init; }
    public required string Genre { get; init; }
    public required string Code { get; init; }
    public required string Language { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Code,
                    opt => opt.MapFrom(src => src.Language.Code));
        }
    }
}
