using LibraryApi.Application.Books.Commands.CreateBook;
using LibraryApi.Application.Books.Commands.DeleteBook;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.FunctionalTests.Books.Commands;

using static Testing;

public class DeleteBookTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidBookId()
    {
        var command = new DeleteBookCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteBook()
    {
        var bookId = await SendAsync(new CreateBookCommand
        {
            Title = "The Secret Garden",
            Author = "Frances Hodgson Burnett",
            Description = "“The Secret Garden” is a touching story about the power of friendship. Mary Lennox is a spoiled and rude little girl sent by her parents to live at her uncle’s huge home. One day while exploring outside the home, she discovers a secret: a locked garden. The secret garden helps her make a friend, and thanks to the love of their friendship she learns to be a better person.",
            Genre = "Children's Novel",
            Language = "En",
        });

        await SendAsync(new DeleteBookCommand(bookId));

        var item = await FindAsync<Book>(bookId);

        item.Should().BeNull();
    }
}
