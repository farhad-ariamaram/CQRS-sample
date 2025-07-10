using CQRS.Domain.Entities;
using CQRS.Infrastructure.Persistence;
using CQRS.Application.Books.Interfaces;
using CQRS.Application.Books.Queries;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<BookDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Books
            .Select(a=> new BookDto{
                Id = a.Id,
                Title = a.Title,
                Author = a.Author
            }).ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Book book, CancellationToken cancellationToken)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Books.FirstOrDefaultAsync(a=>a.Id == id, cancellationToken);
    }
}
