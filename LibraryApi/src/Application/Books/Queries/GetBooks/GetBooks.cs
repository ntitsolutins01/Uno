using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Application.Common.Security;
using LibraryApi.Domain.Constants;

namespace LibraryApi.Application.Books.Queries.GetBooks;

//[Authorize(Roles = Roles.Administrator)]
//[Authorize(Policy = Policies.Read)]
public record GetBooksQuery : IRequest<List<BookDto>>;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<BookDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        return await _context.Books
            .AsNoTracking()
            .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
            .OrderBy(x => x.Title)
            .ToListAsync(cancellationToken);
    }
}
