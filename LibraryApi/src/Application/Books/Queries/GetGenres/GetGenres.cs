using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Application.Common.Security;
using LibraryApi.Domain.Constants;

namespace LibraryApi.Application.Books.Queries.GetGenres;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.Read)]
public record GetGenresQuery : IRequest<List<GenreDto>>;

public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, List<GenreDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGenresQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GenreDto>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Books
            .AsNoTracking()
            .Select(s=>s.Genre).Distinct()
            .ProjectTo<GenreDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;
    }
}
