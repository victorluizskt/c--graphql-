using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using st_graphql.Model;

namespace st_graphql.GraphQL;

public class Mutation
{
    private readonly SqliteConnection _connection = new("Data Source=db.sql");

    private const string InsertAuthor = "INSERT INTO authors(id, name) VALUES (@id, @name)";
    private const string InsertBook =  "INSERT INTO book1(id, title, author_id) VALUES (@id, @title, @author_id)";

    public async Task<Author> AddAuthor(string name)
    {
        var author = new Author
        {
            Id = Guid.NewGuid().ToString(),
            Name = name
        };

        await _connection.OpenAsync();
        
        await _connection.ExecuteAsync(
            InsertAuthor,
            new { id = author.Id, name = author.Name }
        );

        _connection.Close();

        return author;
    }

    public async Task<Book> AddBook(string title, string id)
    {
        var book = new Book
        {
            Id = Guid.NewGuid().ToString(),
            Title = title,
            Author = new Author() { Id = id}
        };
        
        await _connection.OpenAsync();
        await _connection.ExecuteAsync(InsertBook,  new { id = book.Id, title = book.Title, author_id = book.Id });
        
        return book;
    }
}