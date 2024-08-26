namespace Patterns.CodeExamples.Builder;

public record Book(string Title, string? Description, string Author);

public class BookBuilder
{
    private string? _title;
    
    private string? _description;
    
    private string? _author;

    public BookBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public BookBuilder WithDescription(string description)
    {
        _description= description;
        return this;
    }


    public BookBuilder WithAuthor(string author)
    {
        _author = author;
        return this;
    }

    public Book Build()
    {
        return new Book(_title, _description, _author);
    }
}

public class Program
{
    public static void Main()
    {
        var bookBuilder = new BookBuilder();
        var bookWithAllInfo = bookBuilder.WithTitle("title").WithDescription("description").WithAuthor("author").Build();
        var bookWithoutDescription = bookBuilder.WithTitle("title").WithAuthor("author").Build();
        
        Console.WriteLine(bookWithAllInfo.ToString());
        Console.WriteLine(bookWithoutDescription.ToString());
    }
}