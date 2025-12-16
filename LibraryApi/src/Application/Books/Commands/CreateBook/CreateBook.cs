using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Domain.Entities;
using LibraryApi.Domain.ValueObjects;

namespace LibraryApi.Application.Books.Commands.CreateBook;

public record CreateBookCommand : IRequest<int>
{
    public required string Title { get; init; }
    public required string Author { get; init; }
    public required string Description { get; init; }
    public required string Genre { get; init; }
    public required string Language { get; init; }
}

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBookCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var entity = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Description = request.Description,
            Genre = request.Genre,
            Language = (Language)request.Language
        };

        _context.Books.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
