using Dapper;
using Npgsql;

public class AuthorService
{
    private readonly DapperContext _context;

    public AuthorService(DapperContext context)
    {
        _context = context;
    }
    public async Task<List<Author>> GetAuthors()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Select id as Id, first_name as FirstName, last_name as LastName from authors";

            var result = await conn.QueryAsync<Author>(sql);
            return result.ToList();
            
        }
    }

    public async Task<int> InsertAuthors(Author author)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Insert into authors (first_name, last_name) Values ('{author.FirstName}', '{author.LastName}')";
            var result = await conn.ExecuteAsync(sql);
            return result; 
        }
    }

    public async Task<int> UpdateAuthors(Author author)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update authors Set first_name = '{author.FirstName}', last_name = '{author.LastName}' Where id = {author.Id}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }

    public async Task<int> DeleteAuthors(int id)
    {
        using (var conn  = _context.CreateConnection())
        {
            var sql = $"Delete from authors Where id = {id}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
}