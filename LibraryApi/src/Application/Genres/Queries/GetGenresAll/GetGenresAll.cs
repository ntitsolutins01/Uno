using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Application.Common.Security;
using LibraryApi.Domain.Constants;

namespace LibraryApi.Application.Genres.Queries.GetGenresAll;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.Read)]
public record GetGenresAllQuery : IRequest<List<GenresDto>>;

public class GetGenresAllQueryHandler : IRequestHandler<GetGenresAllQuery, List<GenresDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGenresAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GenresDto>> Handle(GetGenresAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Genres
            .AsNoTracking()
            .ProjectTo<GenresDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;
    }
}
