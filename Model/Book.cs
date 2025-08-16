namespace st_graphql.Model;

public class Book
{
    public string? Id { get; set; }
    public string? Title { get; set; }

    public Author? Author { get; set; }
}
