using CQRS.Domain.Entities;
using CQRS.Infrastructure.Persistence;
using CQRS.Application.Books.Interfaces;

namespace CQRS.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(Book book, CancellationToken cancellationToken)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book.Id;
    }
}
