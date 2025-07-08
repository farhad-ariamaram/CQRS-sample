namespace CQRS.Application.Books.Queries;

public class BookDto
{
    public Guid Id {set;get;}
    public string Title {set;get;} = default!;
    public string Author {set;get;} = default!;
}
