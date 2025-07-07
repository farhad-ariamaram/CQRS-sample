using MediatR;
using CQRS.Domain.Entities;

namespace CQRS.Application.Books.Commands;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Guid>
{
    public Task<Guid> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book(request.Title, request.Author);
        //TODO: Database
        return Task.FromResult(book.Id);
    }
}
