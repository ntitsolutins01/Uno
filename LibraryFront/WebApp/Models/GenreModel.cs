using WebApp.Dto;

namespace WebApp.Models
{
    public class GenreModel
    {
        public GenresDto Genre { get; set; }
        public List<GenresDto> Genres { get; set; }

        public class CreateUpdateGenreCommand
        {
            public int Id { get; set; }
            public required string Name { get; init; }
        }
    }

}