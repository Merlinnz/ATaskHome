using Dapper;
using Npgsql;

public class BookService
{
    private readonly DapperContext _context;

    public BookService(DapperContext context)
    {
        _context = context;
    }
    public async Task<List<GetBooks>> GetBooks()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Select books.id as Id, books.book_name as BookName, authors.first_name as FirstName, authors.last_name as LastName, Concat(authors.first_name, ' ' , authors.last_name) as FullName , books.author_id as AuthorId from books join authors ON authors.id = books.author_id";

            var result = await conn.QueryAsync<GetBooks>(sql);
            return result.ToList();
        }
    }

    public async Task<int> InsertBooks(Book book)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Insert into books (book_name, author_id) Values ('{book.BookName}', {book.AuthorId})";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }

    public async Task<int> UpdateBooks(Book book)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update books Set book_name = '{book.BookName}' Where id = {book.Id}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }

    public async Task<int> DeleteBook(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from books Where id = {id}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
}