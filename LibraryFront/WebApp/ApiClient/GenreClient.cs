using WebApp.Dto;
using WebApp.Models;

namespace WebApp.ApiClient
{
    
    public partial class LibraryApiClient
    {
        private const string ResourceGenre = "Genres";

        #region Main Methods

        public Task<long> CreateGenre(GenreModel.CreateUpdateGenreCommand command)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceGenre}"));
            return Post(requestUrl, command);
        }

        public Task<bool> UpdateGenre(int id, GenreModel.CreateUpdateGenreCommand command)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceGenre}/{id}"));
            return Put(requestUrl, command);
        }

        public Task<bool> DeleteGenre(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceGenre}/{id}"));
            return Delete<bool>(requestUrl);
        }

        #endregion

        #region Methods
            
        public List<GenresDto> GetGenresAll()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceGenre}"));
            return Get<List<GenresDto>>(requestUrl);
        }

        public GenresDto GetGenreById(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceGenre}/{id}"));
            return Get<GenresDto>(requestUrl);
        }
        #endregion
    }
}