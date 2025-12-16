using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Genres.Queries;

public class GenresDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Genre, GenresDto>();
        }
    }
}
