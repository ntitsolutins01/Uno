using LibraryApi.Application.Common.Interfaces;

namespace LibraryApi.Application.BooksRental.Commands.UpdateBookRental;

public class UpdateBookRentalCommandValidator : AbstractValidator<UpdateBookRentalCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBookRentalCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.ReturnDate).NotNull().WithMessage("Date of return is required.");

        RuleFor(x => x.ReturnDate)
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Return date must be greater than current date.");
    }
}
