using Microsoft.EntityFrameworkCore;
using CQRS.Domain.Entities;

namespace CQRS.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

    public DbSet<Book> Books => Set<Book>();
}
