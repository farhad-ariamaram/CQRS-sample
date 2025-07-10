using MediatR;

namespace CQRS.Application.Books.Commands;

public class UpdateBookCommand : IRequest<bool>
{
    public Guid Id {get;set;}
    public string Title {get;set;} = default!;
    public string Author {get;set;} = default!;
}
