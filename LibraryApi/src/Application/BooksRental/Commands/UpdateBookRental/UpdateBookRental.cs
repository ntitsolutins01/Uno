using LibraryApi.Application.Common.Interfaces;
using LibraryApi.Domain.ValueObjects;

namespace LibraryApi.Application.BooksRental.Commands.UpdateBookRental;

public record UpdateBookRentalCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required string UserId { get; set; }
    public DateTime? ReturnDate { get; set; }
}

public class UpdateBookRentalCommandHandler : IRequestHandler<UpdateBookRentalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateBookRentalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateBookRentalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.BooksRental
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.UserId = request.UserId;
        entity.ReturnDate = request.ReturnDate;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
