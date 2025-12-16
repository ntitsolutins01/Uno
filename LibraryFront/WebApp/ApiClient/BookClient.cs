using WebApp.Dto;
using WebApp.Models;

namespace WebApp.ApiClient
{
    
    public partial class LibraryApiClient
    {
        private const string ResourceBook = "Books";
        private const string ResourceBookRental = "BooksRental";

        #region Main Methods

        public Task<long> CreateBook(BookModel.CreateUpdateBookCommand command)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceBook}"));
            return Post(requestUrl, command);
        }

        public Task<bool> UpdateBook(int id, BookModel.CreateUpdateBookCommand command)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceBook}/{id}"));
            return Put(requestUrl, command);
        }

        public Task<bool> DeleteBook(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceBook}/{id}"));
            return Delete<bool>(requestUrl);
        }

        public Task<long> RentBook(BookModel.CreateBookRentalCommand command)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceBookRental}/Rent"));
            return Post(requestUrl, command);
        }

        #endregion

        #region Methods

        public List<BookDto> GetBooks()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceBook}"));
            return Get<List<BookDto>>(requestUrl);
        }
        public List<GenreDto> GetGenres()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceBook}/Genres"));
            return Get<List<GenreDto>>(requestUrl);
        }
        public List<LanguageDto> GetLanguages()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceBook}/Languages"));
            return Get<List<LanguageDto>>(requestUrl);
        }

        public BookDto GetBookById(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceBook}/{id}"));
            return Get<BookDto>(requestUrl);
        }

        public Task<BooksFilterDto?> GetBooksByFilter(BooksFilterDto searchFilter)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceBook}/Filter"));
            return GetFilter(requestUrl, searchFilter);
        }
        #endregion
    }
}