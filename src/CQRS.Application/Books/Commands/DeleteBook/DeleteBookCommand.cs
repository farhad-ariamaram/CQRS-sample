using MediatR;

namespace CQRS.Application.Books.Commands;

public class DeleteBookCommand : IRequest<bool>
{
    public Guid Id {get;set;}

    public DeleteBookCommand(Guid id) => Id = id;
}
