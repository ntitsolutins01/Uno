using LibraryApi.Application.Genres.Queries;
using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Application.Common.Security;

namespace LibraryApi.Application.Genres.Queries.GetGenreById;

[Authorize]
public record GetGenreByIdQuery : IRequest<GenresDto>
{
    public required int Id { get; set; }
};

public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenresDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGenreByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenresDto> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Genres
            .Where(x=> x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<GenresDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}
