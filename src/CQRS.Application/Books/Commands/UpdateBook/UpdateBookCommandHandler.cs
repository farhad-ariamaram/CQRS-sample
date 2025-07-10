using MediatR;
using CQRS.Application.Books.Interfaces;

namespace CQRS.Application.Books.Commands;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
{
    private readonly IBookRepository _repository;
    public UpdateBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if(book is null) return false;
        book.Update(request.Title, request.Author);
        await _repository.UpdateAsync(book, cancellationToken);
        return true;
    }
}
