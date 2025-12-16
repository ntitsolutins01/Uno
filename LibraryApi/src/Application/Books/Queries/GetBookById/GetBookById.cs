using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Application.Common.Security;

namespace LibraryApi.Application.Books.Queries.GetBookById;

[Authorize]
public record GetBookByIdQuery : IRequest<BookDto>
{
    public required int Id { get; set; }
};

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBookByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Books
            .Where(x=> x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}
