using LibraryApi.Application.Common.Interfaces;

namespace LibraryApi.Application.Genres.Commands.UpdateGenre;

public record UpdateGenreCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required string Name { get; init; }
}

public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateGenreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Genres
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
