using LibraryApi.Application.Common.Interfaces;

namespace LibraryApi.Application.BooksRental.Queries.GetBookRentalById;

public record GetBookRentalIdQuery : IRequest<BookRentalDto>
{
    public required int Id { get; set; }
};

public class GetBookRentalIdQueryHandler : IRequestHandler<GetBookRentalIdQuery, BookRentalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBookRentalIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BookRentalDto> Handle(GetBookRentalIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Books
            .Where(x=> x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<BookRentalDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}
