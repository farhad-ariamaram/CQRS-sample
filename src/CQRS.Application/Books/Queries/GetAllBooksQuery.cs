using MediatR;

namespace CQRS.Application.Books.Queries;

public class GetAllBooksQuery : IRequest<List<BookDto>>
{
    
}
