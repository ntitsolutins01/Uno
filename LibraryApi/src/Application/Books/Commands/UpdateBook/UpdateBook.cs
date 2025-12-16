using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Domain.ValueObjects;

namespace LibraryApi.Application.Books.Commands.UpdateBook;

public record UpdateBookCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string Author { get; init; }
    public required string Description { get; init; }
    public required string Genre { get; init; }
    public required string Language { get; init; }
}

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateBookCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Books
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;
        entity.Author = request.Author;
        entity.Description = request.Description;
        entity.Genre = request.Genre;
        entity.Language = (Language)request.Language;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
