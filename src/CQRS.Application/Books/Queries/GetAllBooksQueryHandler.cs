using CQRS.Application.Books.Queries;
using MediatR;
using CQRS.Application.Books.Interfaces;

namespace CQRS.Application.Books.Queries;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookDto>>
{
    private readonly IBookRepository _repository;

    public GetAllBooksQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}
