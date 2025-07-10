using FluentValidation;

namespace CQRS.Application.Books.Commands;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x=>x.Title).NotEmpty().WithMessage("Title cannot be empty").MaximumLength(100);
        RuleFor(x=>x.Author).NotEmpty().WithMessage("Title cannot be empty").MaximumLength(100);
    }
}
