using LibraryApi.Application.Common.Interfaces;

namespace LibraryApi.Application.BooksRental.Commands.CreateBookRental;

public class CreateBookRentalCommandValidator : AbstractValidator<CreateBookRentalCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateBookRentalCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        //RuleFor(x => x.RentalDate).NotNull().WithMessage("Date of rental is required.");

        //RuleFor(x => x.RentalDate)
        //    .LessThanOrEqualTo(DateTime.Now.ToString())
        //    .WithMessage("Rental date must be less than current date.");
    }
}
