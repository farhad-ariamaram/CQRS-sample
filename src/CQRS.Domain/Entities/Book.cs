namespace CQRS.Domain.Entities;

public class Book
{
    public Guid Id {private set;get;}
    public string Title {private set;get;}
    public string Author {private set;get;}

    private Book(){}

    public Book(string title, string author)
    {
        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty");

        if(string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Author cannot be empty");

        Id = Guid.NewGuid();
        Title = title;
        Author = author;
    }

    public void Rename(string newTitle)
    {
        if(string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("Title cannot be empty");

        Title = newTitle;
    }

    public void Update(string title, string author)
    {
        Title = title;
        Author = author;
    }
}
