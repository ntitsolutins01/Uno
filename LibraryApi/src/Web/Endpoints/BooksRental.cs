using LibraryApi.Application.BooksRental.Commands.CreateBookRental;
using LibraryApi.Application.BooksRental.Commands.UpdateBookRental;
using LibraryApi.Application.BooksRental.Queries;
using LibraryApi.Application.BooksRental.Queries.GetBooksRental;

namespace LibraryApi.Web.Endpoints;

public class BooksRental : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetBooksRental)
            .MapPost(CreateBookRental, "Rent")
            .MapPut(UpdateBookRental, "Return/{id}");
    }

    public Task<List<BookRentalDto>> GetBooksRental(ISender sender)
    {
        return  sender.Send(new GetBooksRentalQuery());
    }

    public Task<bool> CreateBookRental(ISender sender, CreateBookRentalCommand command)
    {
        return sender.Send(command);
    }

    public async Task<bool> UpdateBookRental(ISender sender, int id, UpdateBookRentalCommand command)
    {
        if (id != command.Id) return false;
        return await sender.Send(command);
    }
}
