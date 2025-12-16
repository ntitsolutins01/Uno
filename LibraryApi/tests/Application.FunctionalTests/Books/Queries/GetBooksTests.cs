using LibraryApi.Application.Books.Queries.GetBooks;
using LibraryApi.Domain.Entities;
using LibraryApi.Domain.ValueObjects;

namespace LibraryApi.Application.FunctionalTests.BookLists.Queries;

using static Testing;

public class GetBooksTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnPriorityLevels()
    {
        await RunAsDefaultUserAsync();

        var query = new GetBooksQuery();

        var result = await SendAsync(query);

        result.Should().NotBeEmpty();
    }

    [Test]
    public async Task ShouldReturnAllBooks()
    {
        await RunAsDefaultUserAsync();

        await AddAsync(
            new Book
            {
                Title = "The Story of Doctor Dolittle",
                Author = "Hugh Lofting",
                Description = "Doctor Dolittle loves animals. He loves them so much that when his many pets scare away his human patients, he learns how to talk to animals and becomes a veterinarian instead. He then travels the world to help animals with his unique ability to speak their language.",
                Genre = "Fantasy Comedy",
                Language = (Language)"En"
            });

        var query = new GetBooksQuery();

        var result = await SendAsync(query);

        result.Should().HaveCount(1);
        result.First().Title.Should().NotBeNull();
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetBooksQuery();

        var action = () => SendAsync(query);

        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}
