using LibraryApi.Application.Common.Interfaces;

namespace LibraryApi.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBookCommandValidator(IApplicationDbContext context)
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

    public async Task<bool> BeUniqueTitle(UpdateBookCommand model, string title, CancellationToken cancellationToken)
    {
        return await _context.Books
            .Where(l => l.Id != model.Id)
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
