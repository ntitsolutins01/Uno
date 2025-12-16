using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Genres.Commands.CreateGenre;

public record CreateGenreCommand : IRequest<int>
{
    public required string Name { get; init; }
}

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateGenreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var entity = new Genre
        {
            Name = request.Name
        };

        _context.Genres.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
