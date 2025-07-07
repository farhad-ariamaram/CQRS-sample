using MediatR;
using CQRS.Domain.Entities;
using CQRS.Application.Books.Interfaces;

namespace CQRS.Application.Books.Commands;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Guid>
{
    private readonly IBookRepository _repository;

    public AddBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book(request.Title, request.Author);
        return await _repository.AddAsync(book, cancellationToken);
    }
}
