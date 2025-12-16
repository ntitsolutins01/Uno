using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Application.Common.Security;
using LibraryApi.Domain.Constants;

namespace LibraryApi.Application.Books.Queries.GetLanguages;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.Read)]
public record GetLanguagesQuery : IRequest<List<LanguageDto>>;

public class GetLanguagesQueryHandler : IRequestHandler<GetLanguagesQuery, List<LanguageDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLanguagesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LanguageDto>> Handle(GetLanguagesQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Books
            .AsNoTracking()
            .ProjectTo<LanguageDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result.DistinctBy(d=>d.Code).ToList();
    }
}
