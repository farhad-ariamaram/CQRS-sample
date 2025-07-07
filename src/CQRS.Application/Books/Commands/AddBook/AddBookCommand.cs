using MediatR;

namespace CQRS.Application.Books.Commands;

public class AddBookCommand : IRequest<Guid>
{
    public string Title{get;set;}
    public string Author{get;set;}
}
