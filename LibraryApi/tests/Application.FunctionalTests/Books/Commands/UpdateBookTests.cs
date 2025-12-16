using LibraryApi.Application.Books.Commands.CreateBook;
using LibraryApi.Application.Books.Commands.UpdateBook;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.FunctionalTests.Books.Commands;

using static Testing;

public class UpdateBookTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidBookId()
    {
        var command = new UpdateBookCommand
        {
            Id = 99,
            Title = "New Title",
            Author = "New Author",
            Description = "New Description",
            Genre = "New Genre",
            Language = "New Language"
        };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateBook()
    {
        var userId = await RunAsDefaultUserAsync();

        var bookId = await SendAsync(new CreateBookCommand
        {
            Title = "Treasure Island",
            Author = "Robert Louis Stevenson",
            Description = "Everything you know about pirates probably came from this one book: wooden legs, parrots on the shoulder and treasure maps. “Treasure Island” is the story of a boy who sails on a ship searching for treasure, but instead finds himself surrounded by terrible pirates. It’s also a story about growing up, full of action and adventure.",
            Genre = "Adventure",
            Language = "En"
        });

        var command = new UpdateBookCommand
        {
            Id = bookId,
            Title = "Ilha do Tesouro",
            Author = "Robert Louis Stevenson",
            Description = "Tudo o que você sabe sobre piratas provavelmente veio deste livro: pernas de pau, papagaios no ombro e mapas do tesouro. \"A Ilha do Tesouro\" é a história de um menino que navega em um navio em busca de tesouros, mas acaba cercado por piratas terríveis. É também uma história sobre crescimento, cheia de ação e aventura.",
            Genre = "Aventura",
            Language = "Pt"
        };

        await SendAsync(command);

        var item = await FindAsync<Book>(bookId);

        item.Should().NotBeNull();
        item!.Title.Should().Be(command.Title);
        item.LastModifiedBy.Should().NotBeNull();
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
