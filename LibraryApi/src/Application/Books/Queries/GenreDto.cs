using LibraryApi.Domain.Entities;
using LibraryApi.Domain.ValueObjects;

namespace LibraryApi.Application.Books.Queries;

public class GenreDto
{
    public required string Genre { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<string, GenreDto>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src=>src));
        }
    }
}
