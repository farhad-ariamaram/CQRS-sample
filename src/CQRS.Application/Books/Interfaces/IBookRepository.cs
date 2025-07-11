using CQRS.Domain.Entities;
using CQRS.Application.Books.Queries;

namespace CQRS.Application.Books.Interfaces;

public interface IBookRepository
{
    Task<Guid> AddAsync(Book book, CancellationToken cancellationToken);
    Task<List<BookDto>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(Book book, CancellationToken cancellationToken);
    Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken); 
    Task DeleteAsync(Book book, CancellationToken cancellationToken);
}
