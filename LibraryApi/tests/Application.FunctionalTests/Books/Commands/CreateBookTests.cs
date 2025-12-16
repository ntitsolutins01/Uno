using LibraryApi.Application.Books.Commands.CreateBook;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.FunctionalTests.Books.Commands;

using static Testing;

public class CreateBookTests : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateBook()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateBookCommand
        {
            Title = "The Story of Doctor Dolittle",
            Author = "Hugh Lofting",
            Description = "Doctor Dolittle loves animals. He loves them so much that when his many pets scare away his human patients, he learns how to talk to animals and becomes a veterinarian instead. He then travels the world to help animals with his unique ability to speak their language.",
            Genre = "Fantasy Comedy",
            Language = "En"
        };

        var bookId = await SendAsync(command);

        var book = await FindAsync<Book>(bookId);

        if (book != null)
        {
            book.Should().NotBeNull();
            book.Title.Should().Be(command.Title);
            book.CreatedBy.Should().Be(userId);
            book.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
            book.LastModifiedBy.Should().Be(userId);
            book.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        }
    }
}
