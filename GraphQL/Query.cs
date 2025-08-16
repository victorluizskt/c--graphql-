using Dapper;
using Microsoft.Data.Sqlite;
using st_graphql.Model;

namespace st_graphql.GraphQL;

public class Query
{
    private readonly SqliteConnection _connection = new("Data Source=db.sql");
    
    public async Task<Author?> GetAuthorById(string id)
    {
        await _connection.OpenAsync();
        var authorById = await _connection.QueryFirstOrDefaultAsync<Author>("select * from authors where Id = @id", new { id });
        _connection.Close();
        return authorById;
    }
    
    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        await _connection.OpenAsync();
        var authors = await _connection.QueryAsync<Author>("select * from authors");
        _connection.Close();
        
        return authors;
    }

    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        await _connection.OpenAsync();
        var books = await _connection.QueryAsync<Book, Author, Book>(
            "select * from book1 b inner join authors a on b.author_id = a.id",
            (book, author) =>
            {
                book.Author = author; 
                return book;
            },
            splitOn: "id" 
        );
        return books;
    }

    public async Task<Book?> GetBookById(string id)
    {
        await _connection.OpenAsync();
        return await _connection.QueryFirstOrDefaultAsync<Book>("select * from book1 where Id = @id", new { id });
    }
}
