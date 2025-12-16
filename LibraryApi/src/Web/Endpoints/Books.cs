using DnaBrasilApi.Application.Books.Queries.GetBooksByFilter;
using LibraryApi.Application.Books.Commands.CreateBook;
using LibraryApi.Application.Books.Commands.DeleteBook;
using LibraryApi.Application.Books.Commands.UpdateBook;
using LibraryApi.Application.Books.Queries;
using LibraryApi.Application.Books.Queries.GetBookById;
using LibraryApi.Application.Books.Queries.GetBooks;
using LibraryApi.Application.Books.Queries.GetGenres;
using LibraryApi.Application.Books.Queries.GetLanguages;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Web.Endpoints;

public class Books : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetBooks)
            .MapGet(GetGenres, "Genres")
            .MapGet(GetLanguages, "Languages")
            .MapPost(CreateBook)
            .MapPut(UpdateBook, "{id}")
            .MapDelete(DeleteBook, "{id}")
            .MapGet(GetBookById, "{id}")
            .MapPost(GetBooksByFilter, "Filter");
    }

    public Task<List<BookDto>> GetBooks(ISender sender)
    {
        return  sender.Send(new GetBooksQuery());
    }
    public Task<List<GenreDto>> GetGenres(ISender sender)
    {
        return  sender.Send(new GetGenresQuery());
    }
    public Task<List<LanguageDto>> GetLanguages(ISender sender)
    {
        return  sender.Send(new GetLanguagesQuery());
    }

    public Task<int> CreateBook(ISender sender, CreateBookCommand command)
    {
        return sender.Send(command);
    }

    public async Task<bool> UpdateBook(ISender sender, int id, UpdateBookCommand command)
    {
        if (id != command.Id) return false;
        return await sender.Send(command);
    }

    public async Task<bool> DeleteBook(ISender sender, int id)
    {
        return await sender.Send(new DeleteBookCommand(id));
    }

    public async Task<BookDto> GetBookById(ISender sender, int id)
    {
        return await sender.Send(new GetBookByIdQuery() { Id = id });
    }

    public async Task<BooksFilterDto> GetBooksByFilter(ISender sender, [FromBody] BooksFilterDto search)
    {
        var result = await sender.Send(new GetBooksByFilterQuery() { SearchFilter = search });

        search.Books = result;

        return search;
    }
}
