using FluentValidation;

namespace CQRS.Application.Books.Commands.AddBook;

public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
{
    public AddBookCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required").MaximumLength(100);
        RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required").MaximumLength(60);
    }
}
