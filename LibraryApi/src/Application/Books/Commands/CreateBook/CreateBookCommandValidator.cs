using LibraryApi.Application.Common.Interfaces;

namespace LibraryApi.Application.Books.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateBookCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(200)
            .MustAsync(BeUniqueTitle)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
        RuleFor(v => v.Author)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(v => v.Description)
            .NotEmpty()
            .MaximumLength(500);
        RuleFor(v => v.Genre)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(v => v.Language)
            .NotEmpty()
            .MaximumLength(2);
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.Books
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
