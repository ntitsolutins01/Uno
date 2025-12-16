using LibraryApi.Application.Common.Interfaces;

namespace LibraryApi.Application.Books.Commands.DeleteBook;

public record DeleteBookCommand(int Id) : IRequest<bool>;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteBookCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Books
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Books.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
