using LibraryApi.Application.Books.Queries;
using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Domain.Entities;

namespace DnaBrasilApi.Application.Books.Queries.GetBooksByFilter;

public record GetBooksByFilterQuery : IRequest<List<BookDto>>
{
    public required BooksFilterDto SearchFilter { get; init; }
}

public class GetBooksByFilterQueryHandler : IRequestHandler<GetBooksByFilterQuery, List<BookDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBooksByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BookDto>> Handle(GetBooksByFilterQuery request, CancellationToken cancellationToken)
    {
        var books = _context.Books
            .AsNoTracking();

        var result = FilterBooks(books, request.SearchFilter!, cancellationToken)
            .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
            .OrderByDescending(t => t.Id)
            .ToListAsync(cancellationToken);

        return await result;
    }

    private IQueryable<Book> FilterBooks(IQueryable<Book> Books, BooksFilterDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.Code))
        {
            Books = Books.Where(u => u.Language.Code == search.Code);
        }

        if (!string.IsNullOrWhiteSpace(search.Genre))
        {
            Books = Books.Where(u => u.Genre == search.Genre);
        }

        return Books;
    }
}
