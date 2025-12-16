using LibraryApi.Application.Common.Interfaces;

namespace LibraryApi.Application.BooksRental.Queries.GetBooksRental;

public record GetBooksRentalQuery : IRequest<List<BookRentalDto>>;

public class GetBooksRentalQueryHandler : IRequestHandler<GetBooksRentalQuery, List<BookRentalDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBooksRentalQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BookRentalDto>> Handle(GetBooksRentalQuery request, CancellationToken cancellationToken)
    {
        return await _context.BooksRental
            .AsNoTracking()
            .ProjectTo<BookRentalDto>(_mapper.ConfigurationProvider)
            .OrderBy(x => x.ReturnDate)
            .ToListAsync(cancellationToken);
    }
}
