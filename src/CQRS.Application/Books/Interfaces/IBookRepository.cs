using CQRS.Domain.Entities;

namespace CQRS.Application.Books.Interfaces;

public interface IBookRepository
{
    Task<Guid> AddAsync(Book book, CancellationToken cancellationToken);
}
