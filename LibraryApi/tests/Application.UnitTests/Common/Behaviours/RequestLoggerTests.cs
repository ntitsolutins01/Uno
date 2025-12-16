using LibraryApi.Application.Common.Behaviours;
using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Application.Books.Commands.CreateBook;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace LibraryApi.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateBookCommand>> _logger = null!;
    private Mock<IUser> _user = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateBookCommand>>();
        _user = new Mock<IUser>();
        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _user.Setup(x => x.Id).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateBookCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new CreateBookCommand
        {
            Title = "Black Beauty",
            Author = "Anna Sewell",
            Description = "“Black Beauty” is one the best-selling books of all time, and for a good reason—this story about a horse teaches kindness towards animals and people. The story is told by the horse. It describes his life and the many cruel people and difficult times he had to live through before finding peace. It’s a great read even if you’re not a fan of horses.",
            Genre = "Fiction",
            Language = "English"
        }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateBookCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new CreateBookCommand {
            Title = "Heidi",
            Author = "Johana Spyri",
            Description = "“Heidi” is a book often described as being “for children and for people who love children.” It does a great job of showing the world through a little girl’s eyes as she explores the mountains in Switzerland. She makes many friends along the way, but also deals with the kinds of fears that a child would have, like being alone and away from the people who love you. It’s a long book, but one that’s easy to fall in love with.",
            Genre = "Romance",
            Language = "English"
        }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
    }
}
