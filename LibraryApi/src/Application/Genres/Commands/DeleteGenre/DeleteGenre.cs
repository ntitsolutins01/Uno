using LibraryApi.Application.Common.Interfaces;

namespace LibraryApi.Application.Genres.Commands.DeleteGenre;

public record DeleteGenreCommand(int Id) : IRequest<bool>;

public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteGenreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Genres
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Genres.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
